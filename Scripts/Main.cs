using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Main : MonoBehaviour {

	public List<Enemy> enemyList=new List<Enemy>();
	public float EXP=0;
	public Enemy[] enemies;
	public GameObject _fireBall;
	public Transform _camera;
	public Transform hand;
	protected Animator animator;
	public Enemy enemy;
	int selectEnemy=0;
	static public bool fireGenCheck=false;
	void OnGUI(){
		GUI.Box (new Rect(Screen.width/2-100,Screen.height-20,200,20),EXP.ToString());
	}
	void Start () {
		animator = GetComponent<Animator>();
		enemies = FindObjectsOfType<Enemy>();
		for(int i=0;i<enemies.Length;i++){
			enemyList.Add(enemies[i]);
		}
		
	}	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab)){
			for(int i=0;i<enemyList.Count;i++)
				Debug.Log(Vector3.Distance(enemies[i].transform.localPosition,this.transform.position).ToString());
			if(selectEnemy>=enemyList.Count){
				selectEnemy=0;
			}
			for(int i=0;i<enemyList.Count;i++){
				enemyList[i].selected=false;
			}
			enemyList[selectEnemy].selected=true;
			selectEnemy++;


		}

		if(fireGenCheck==false){
			if(Input.GetKeyDown(KeyCode.E)){
				Instantiate(_fireBall,hand.transform.position,_camera.transform.rotation);
				fireGenCheck=true;
			}
		}
		if(Input.GetMouseButtonDown(0)){
			animator.SetBool("LeftClick", true);
		}
		else
			animator.SetBool("LeftClick", false);
	}
}
