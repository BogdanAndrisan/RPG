using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private Animator animator;
	private int HP = 10;
	private bool test=false;
	private bool enemyHit=false;
	public bool selected=false;
	public Main main;
	private Quaternion originalRot;
	private Vector3 originalPos;
	public float delay=0;

	void Start () {
		animator=GetComponent<Animator>();
		main = FindObjectOfType<Main>();
		originalRot=this.transform.rotation;
		originalPos=this.transform.position;

	}
	void OnGUI(){
		if(selected==true){
			GUI.Box(new Rect(20,20, 200, 20), this.gameObject.name.ToString()+" : "+HP.ToString());
		}
	}
	public void GetREKT(){
		HP-=10;
		enemyHit=true;
	}
	void stopAttack(){
		animator.SetBool("attack",false);
	}
	void damagePlayer(){
		main.att.HP--;
	}
	void Update () {
		delay-=Time.deltaTime;
		if(Vector3.Distance(this.transform.position,main.transform.position)<1.6f && delay<=0){
			animator.SetBool("attack",true);
			Invoke("stopAttack",0.63f);
			Invoke("damagePlayer",0.3f);
			delay=2f;

		}
		if(Vector3.Distance(this.transform.position,main.transform.position)<5 && Vector3.Distance(this.transform.position,main.transform.position)>1.5f){
			Vector3 targetPosition=new Vector3(main.transform.position.x,this.transform.position.y,main.transform.position.z);
			//transform.LookAt(targetPosition);
			Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation,targetRotation,Time.deltaTime*5);
			animator.SetFloat("move",1f);
		}
		else{
			if(Vector3.Distance(this.transform.position,main.transform.position)<1.6f){
				Vector3 targetPosition=new Vector3(main.transform.position.x,this.transform.position.y,main.transform.position.z);
				Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
				transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime*5);
				animator.SetFloat("move",0f);
			}
			if(Vector3.Distance(this.transform.position,main.transform.position)>5){
				transform.rotation = Quaternion.Slerp (transform.rotation, originalRot, Time.deltaTime*5);
				animator.SetFloat("move",0f);
			}
		}

		if(HP<=0){
			main.att.EXP+=100;
			Destroy(gameObject);
			main.enemyList.Remove(this);
		}
		//float move = Input.GetAxis("Vertical");
		//animator.SetFloat("move",move);
		if(Input.GetKeyDown(KeyCode.R)){
			animator.SetBool("Test",!test);
			test=!test;
			rigidbody.useGravity=!rigidbody.useGravity;
		}
	}
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.layer==8){
			Debug.Log("Enemyx hit");
			GetREKT();
		}
	}
}
