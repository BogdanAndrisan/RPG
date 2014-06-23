using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {
	//public Transform explosionPrefab;
	public GameObject IC;
	public GameObject OC;
	public GameObject LS;
	private GameObject Ethan_hand;
	private GameObject camera;
	private bool check=false;

	Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
	void Start () {
		Ethan_hand = GameObject.Find("char_ethan_RightHandMiddle1");
		camera = GameObject.Find("Main Camera");
		this.rigidbody.useGravity=false;
		this.collider.enabled=false;
	}
	void Update () {


		if(check==false){
			this.transform.position=Ethan_hand.transform.position;
		}
		if(check==false){
			if(Input.GetMouseButton(0)){
				Invoke ("wait",0.3f);
			}
		}
	}
	void wait(){

		this.transform.rotation=camera.transform.rotation;
		rigidbody.AddRelativeForce(Vector3.forward*1);
		this.rigidbody.useGravity = true;
		this.collider.enabled = true;
		check=true;
		Main.fireGenCheck=false;

	}
	void wait2(){
		Destroy(gameObject);
	}
	void DestroyGO(){
		IC.particleEmitter.minEmission=0;
		IC.particleEmitter.maxEmission=0;
		OC.particleEmitter.minEmission=0;
		OC.particleEmitter.maxEmission=0;
		wait2 ();
	}
	//need fix
	void OnCollisionEnter(Collision collision) {
		IC.particleEmitter.rndVelocity=new Vector3(2,2,2);
		DestroyGO();
		if(collision.gameObject.name=="Enemy"){
			Debug.Log("Enemy hit");
		}
	}
}
