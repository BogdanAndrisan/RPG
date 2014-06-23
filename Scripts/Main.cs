using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Main : MonoBehaviour {

	public float HP=100;
	public float EXP=0;

	public List<Enemy> enemyList=new List<Enemy>();
	public Enemy temp;

	public Enemy[] enemies;
	public GameObject _fireBall;
	public GameObject _camera;
	public Transform hand;
	protected Animator animator;
	public GameObject skelly;
	int selectEnemy=0;
	static public bool fireGenCheck=false;
	public void setValues(int HP,int EXP){
		this.HP=HP;
		this.EXP=EXP;
	}
	void OnGUI(){
		GUI.Box (new Rect(Screen.width/2-100,Screen.height-20,200,20),"Exp:"+EXP.ToString());
		GUI.Box (new Rect(Screen.width/2-100,Screen.height-45,200,20),"HP:"+HP.ToString());
	}
	void Start () {
		GameObject newObj=Instantiate(skelly,new Vector3(0,0,0),Quaternion.identity) as GameObject;
		newObj.name="Skelly";
		_camera = GameObject.FindGameObjectWithTag("MainCamera");
		animator = GetComponent<Animator>();
		enemies = FindObjectsOfType<Enemy>();
		for(int i=0;i<enemies.Length;i++){
			enemyList.Add(enemies[i]);
		}
		
	}	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab)){
			if(enemyList.Count>0){
				for(int i=0;i<(enemyList.Count-1);++i){
					for(int j=0;j<(enemyList.Count-1-i);++j){
						if(Vector3.Distance(enemyList[j].transform.position,this.transform.position)>
						   Vector3.Distance(enemyList[j+1].transform.position,this.transform.position)){
							temp=enemyList[j+1];
							enemyList[j+1]=enemyList[j];
							enemyList[j]=temp;
						}
					}
				}
				for(int i=0;i<enemyList.Count;i++)
					Debug.Log(Vector3.Distance(enemyList[i].transform.localPosition,this.transform.position).ToString());
				if(selectEnemy>=enemyList.Count){
					selectEnemy=0;
				}
				for(int i=0;i<enemyList.Count;i++){
					enemyList[i].selected=false;
					enemyList[i].particleEmitter.minEmission=0;
					enemyList[i].particleEmitter.maxEmission=0;
				}
				enemyList[selectEnemy].selected=true;
				enemyList[selectEnemy].particleEmitter.minEmission=150;
				enemyList[selectEnemy].particleEmitter.maxEmission=150;
				selectEnemy++;
			}
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
