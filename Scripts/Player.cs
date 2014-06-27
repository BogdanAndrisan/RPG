using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player : MonoBehaviour {
	
	public Attributes att=new Attributes();

	public GameObject _fireBall;
	public GameObject _camera;
	public Transform hand;
	protected Animator animator;
	static public bool fireGenCheck=false;

	public void setValues(int STR){
		att.STR = STR;
		att.Recalculate();
	}
	void Start () {
		_camera = GameObject.FindGameObjectWithTag("MainCamera");
		hand = transform.Find("Ethan/char_ethan_skeleton/char_ethan_Hips/char_ethan_Spine/" +
			"char_ethan_Spine1/char_ethan_Spine2/char_ethan_Neck/char_ethan_RightShoulder/char_ethan_RightArm/" +
			"char_ethan_RightForeArm/char_ethan_RightHand/char_ethan_RightHandMiddle1");
		animator = GetComponent<Animator>();
		name="Player";
	}	
	void Update () {
		att.LevelUp();
		FireballCheck();
	}
	void FireballCheck(){
		if(fireGenCheck==false){
			if(Input.GetKeyDown(KeyCode.E)){
				Instantiate(_fireBall,hand.transform.position,_camera.transform.rotation);
				fireGenCheck=true;
				att.MP--;
			}
		}
		if(Input.GetMouseButtonDown(1)){
			animator.SetBool("LeftClick", true);
		}
		else{
			animator.SetBool("LeftClick", false);
		}
	}

}
