using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GUIscript : MonoBehaviour {
	private Player player;
	public List<Enemy> enemyList=new List<Enemy>();
	public Enemy temp;
	public Enemy[] enemies;
	public GameObject skelly;
	private int selectEnemy=0;
	void Start(){
		GameObject newObj=Instantiate(skelly,new Vector3(0,0,0),Quaternion.identity) as GameObject;
		newObj.name="Skelly";
		player = FindObjectOfType<Player>();
		enemies = FindObjectsOfType<Enemy>();
		for(int i=0;i<enemies.Length;i++){
			enemyList.Add(enemies[i]);
		}
	}
	void OnGUI(){
		GUI.Box (new Rect(Screen.width/2-100,Screen.height-20,200,20),"Exp:"+player.att.EXP.ToString());
		GUI.Box (new Rect(Screen.width/2-100,Screen.height-45,200,20),"HP:"+player.att.HP.ToString());
		ShowSelectedEnemyGUI();
	}
	void ShowSelectedEnemyGUI(){
		if(selectEnemy==0){
			if(enemyList[selectEnemy].selected==true){
				GUI.Box(new Rect(20,20, 200, 20), enemyList[selectEnemy].gameObject.name.ToString()+" : "+enemyList[selectEnemy].HP.ToString());
			}
		}else{
			if(enemyList[selectEnemy-1].selected==true){
				GUI.Box(new Rect(20,20, 200, 20), enemyList[selectEnemy-1].gameObject.name.ToString()+" : "+enemyList[selectEnemy-1].HP.ToString());
			}
		}
	}

	void Update(){
		SelectEnemy();
	}
	void SelectEnemy(){
		if(Input.GetKeyDown(KeyCode.Tab)){
			if(enemyList.Count>0){
				for(int i=0;i<(enemyList.Count-1);++i){
					for(int j=0;j<(enemyList.Count-1-i);++j){
						if(Vector3.Distance(enemyList[j].transform.position,player.transform.position)>
						   Vector3.Distance(enemyList[j+1].transform.position,player.transform.position)){
							temp=enemyList[j+1];
							enemyList[j+1]=enemyList[j];
							enemyList[j]=temp;
						}
					}
				}
				for(int i=0;i<enemyList.Count;i++)
					Debug.Log(Vector3.Distance(enemyList[i].transform.localPosition,player.transform.position).ToString());
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
	}
}
