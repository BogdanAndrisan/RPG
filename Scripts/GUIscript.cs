﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GUIscript : MonoBehaviour {
	private Player player;
	public List<Enemy> enemyList=new List<Enemy>();
	public Enemy temp;
	public Enemy[] enemies;
	public GameObject skelly;
	public int selectEnemy=0;

	public GUISkin skin;
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
		GUI.skin = skin;
		PlayerGUI();
		ShowSelectedEnemyGUI();
	}
	void PlayerGUI(){
		GUI.Box (new Rect(20,5,150,20),player.name+" - "+player.att.level,"HPBar");
		GUI.Box (new Rect(10,5,10,20),"","HPBarLeft");
		GUI.Box (new Rect(170,5,10,20),"","HPBarRight");
		GUI.Box (new Rect(40,Screen.height-20,(float)((Screen.width-80)*(player.att.EXP/player.att.EXPtoLevel)),20),"","HPBar");
		GUI.Box (new Rect(40,Screen.height-20,Screen.width-80,20),"Exp:"+player.att.EXP.ToString());
		GUI.Box (new Rect(30,Screen.height-20,10,20),"","HPBarLeft");
		GUI.Box (new Rect(Screen.width-40,Screen.height-20,10,20),"","HPBarRight");
		GUI.Box (new Rect(20,30,150,20),"HP:"+player.att.getHP().ToString(),"HPBar");
		GUI.Box (new Rect(10,30,10,20),"","HPBarLeft");
		GUI.Box (new Rect(170,30,10,20),"","HPBarRight");
		GUI.Box (new Rect(20,55,150,20),"MP:"+player.att.getMP().ToString(),"MPBar");
		GUI.Box (new Rect(10,55,10,20),"","MPBarLeft");
		GUI.Box (new Rect(170,55,10,20),"","MPBarRight");
		GUI.Box (new Rect(20,80,150,20),"EN:"+player.att.getEN().ToString(),"ENBar");
		GUI.Box (new Rect(10,80,10,20),"","ENBarLeft");
		GUI.Box (new Rect(170,80,10,20),"","ENBarRight");
	}
	void EnemyGUI(){
		GUI.Box(new Rect(200,30, 150, 20), enemyList[0].gameObject.name.ToString()+" : "+enemyList[0].HP.ToString());
		GUI.Box (new Rect(190,30,10,20),"","HPBarLeft");
		GUI.Box (new Rect(350,30,10,20),"","HPBarRight");
	}
	void ShowSelectedEnemyGUI(){
		if(enemyList.Count>0){
			if(enemyList[0]){
				EnemyGUI ();
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
