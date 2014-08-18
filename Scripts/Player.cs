using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;
	public Animator animator;
	public float forward = 0f;
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;

	void Start(){
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		if (networkView.isMine)
		{
			InputMovement();
			InputColorChange();
		}
		else
		{
			SyncedMovement();
		}
	}

	void InputMovement()
	{
		if (Input.GetKey(KeyCode.W)){
			//rigidbody.MovePosition(rigidbody.position + Vector3.forward * speed * Time.deltaTime);
			animator.SetFloat("Forward" , 1f);

		}
		else{
			animator.SetFloat("Forward" , 0f);
		}
		
		if (Input.GetKey(KeyCode.S))
			rigidbody.MovePosition(rigidbody.position - Vector3.forward * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.D))
			rigidbody.MovePosition(rigidbody.position + Vector3.right * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.A))
			rigidbody.MovePosition(rigidbody.position - Vector3.right * speed * Time.deltaTime);
	}
	private void InputColorChange()
	{
		if (Input.GetKeyDown(KeyCode.R))
			ChangeColorTo(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
	}
	
	[RPC] void ChangeColorTo(Vector3 color)
	{
		renderer.material.color = new Color(color.x, color.y, color.z, 1f);
		
		if (networkView.isMine)
			networkView.RPC("ChangeColorTo", RPCMode.OthersBuffered,color);
	}

	private void SyncedMovement(){
		syncTime += Time.deltaTime;
		rigidbody.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime/syncDelay);
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info){
		Vector3 syncPosition = Vector3.zero;
		Vector3 syncVelocity = Vector3.zero;

		if (stream.isWriting)
		{
			syncPosition = rigidbody.position;
			stream.Serialize(ref syncPosition);
			
			syncVelocity = rigidbody.velocity;
			stream.Serialize(ref syncVelocity);

			stream.Serialize(ref forward);
			Debug.Log ("Forward value:" + forward);
		}
		else
		{
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncVelocity);

			stream.Serialize(ref forward);

			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			syncStartPosition = rigidbody.position;
		}
	}
}
