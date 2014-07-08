using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private Animator animator;
	public Attributes att=new Attributes();
	public int index;
	private bool test=false;
	private bool enemyHit=false;
	public Player player;
	public GUIscript guiScript;
	private Quaternion originalRot;
	private Vector3 originalPos;
	public float delay=0;

	void Start () {
		att.Recalculate();
		animator=GetComponent<Animator>();
		player = FindObjectOfType<Player>();
		guiScript = FindObjectOfType<GUIscript>();
		originalRot=this.transform.rotation;
		originalPos=this.transform.position;
	}
	void OnGUI(){

	}
	public void GetDamagedByCollision(){
		att.HP-=10;
		enemyHit=true;
	}
	void stopAttack(){
		animator.SetBool("attack",false);
	}
	void damagePlayer(){
		player.att.HP--;
	}
	void Update () {
		BasicMoveAI();
		CheckHP ();
		DanceDanceRevolution();
	}
	void BasicMoveAI(){
		delay-=Time.deltaTime;
		if(Vector3.Distance(this.transform.position,player.transform.position)<1.6f && delay<=0 && animator.GetBool("dead")==false){
			animator.SetBool("attack",true);
			Invoke("stopAttack",0.63f);
			Invoke("damagePlayer",0.3f);
			delay=2f;
			
		}
		if(Vector3.Distance(this.transform.position,player.transform.position)<5 && Vector3.Distance(this.transform.position,player.transform.position)>1.5f && animator.GetBool("dead")==false){
			Vector3 targetPosition=new Vector3(player.transform.position.x,this.transform.position.y,player.transform.position.z);
			//transform.LookAt(targetPosition);
			Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation,targetRotation,Time.deltaTime*5);
			animator.SetFloat("move",1f);
		}
		else{
			if(Vector3.Distance(this.transform.position,player.transform.position)<1.6f && animator.GetBool("dead")==false){
				Vector3 targetPosition=new Vector3(player.transform.position.x,this.transform.position.y,player.transform.position.z);
				Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
				transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime*5);
				animator.SetFloat("move",0f);
			}
			if(Vector3.Distance(this.transform.position,player.transform.position)>5 && animator.GetBool("dead")==false){
				transform.rotation = Quaternion.Slerp (transform.rotation, originalRot, Time.deltaTime*5);
				animator.SetFloat("move",0f);
			}
		}
	}
	void CheckHP(){
		if(att.HP<=0){
			animator.SetBool("dead",true);
			Invoke ("Death",4f);
		}
	}
	void Death(){
		player.att.EXP+=100;
		Destroy(gameObject);
		guiScript.selectEnemy--;
		guiScript.enemyList.Remove(this);
	}
	void DanceDanceRevolution(){
		if(Input.GetKeyDown(KeyCode.R)){
			animator.SetBool("Test",!test);
			test=!test;
			rigidbody.useGravity=!rigidbody.useGravity;
		}
	}
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.layer==8){
			Debug.Log("Enemyx hit by fireball");
			GetDamagedByCollision();
		}
		/*if(collision.gameObject.layer==11){
			Debug.Log("Enemy hit by punch");
			GetDamagedByCollision();
		}*/
	}
}
