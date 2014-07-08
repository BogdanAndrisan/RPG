using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public string itemName;
	public Texture icon;
	public int attackPower=10;
	public Inventory inv;
	void Start () {
		inv = FindObjectOfType<Inventory>();
		name=itemName;
	}
	

	void Update () {
	
	}
	void OnMouseOver(){
		Debug.Log("Mouse is over item");
	}
	void OnMouseDown() {
		Debug.Log("clicked on "+this.name);
		if(inv.item.Count<16)
			inv.item.Add(this);
		else
			Debug.Log ("Inventory is Full");
		inv.RecheckInventory();
	}
}
