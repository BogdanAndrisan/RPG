using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private Animator animator;
	private int HP = 100;
	private bool test=false;
	private bool enemyHit=false;
	public bool selected=false;
	public Main main;
	void Start () {
		animator=GetComponent<Animator>();
		main = FindObjectOfType<Main>();
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
	void Update () {
		if(HP<=0){
			main.EXP+=100;
			Destroy(gameObject);
			main.enemyList.Remove(this);
		}
		float move = Input.GetAxis("Vertical");
		animator.SetFloat("move",move);
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
