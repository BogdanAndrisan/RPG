using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GUIscript : MonoBehaviour {
	private Player player;
	public List<Enemy> enemyList=new List<Enemy>();
	public Enemy temp;
	public Enemy[] enemies;
	public GameObject skelly;
	public int selectEnemy=0;
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
		if(enemyList.Count>0){
			if(enemyList[0]){
				GUI.Box(new Rect(20,20, 200, 20), enemyList[0].gameObject.name.ToString()+" : "+enemyList[0].HP.ToString());
				enemyList[0].particleEmitter.minEmission=200;
				enemyList[0].particleEmitter.maxEmission=200;
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
	
				for(int i=0;i<enemyList.Count;i++){
					enemyList[i].index=i;
					enemyList[i].particleEmitter.minEmission=0;
					enemyList[i].particleEmitter.maxEmission=0;
				}
			}
		}
	}
}
