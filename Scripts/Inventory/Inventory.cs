using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	private Vector3 dropLoc;
	private Player player;
	public Texture tex;
	public List<Item> item;
	public bool seeInv=false;
	void Start () {
		item=new List<Item>();
		player=GetComponent<Player>();
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.I)){
			seeInv=!seeInv;
		}
	}

	public void OnGUI(){
		int x=-1;
		int y=0;
		if(seeInv==true){
			GUI.DrawTexture(new Rect(Screen.width-205,15,130,130),tex);
			for(int i=0;i<item.Count;i++){
				x++;
				if(i%4==0 && i!=0){
					y++;
					x=0;
				}
				if(GUI.Button (new Rect(Screen.width-200+x*30,20+y*30,30,30),item[i].icon)){
					if(Input.GetMouseButtonUp(0)){
						Debug.Log(item[i].attackPower);
						dropLoc=player.transform.position+player.transform.forward+player.transform.up;
						Instantiate(item[i],dropLoc,Quaternion.identity);
						item.RemoveAt(i);
					}
				}
			}
		}
	}

	public void RecheckInventory(){
		Debug.Log("Inv was rechecked");
	}
}
