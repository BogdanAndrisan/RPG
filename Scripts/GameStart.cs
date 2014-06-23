using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	public GameObject playerPrefab;
	private GameObject player; 
	void Awake(){
		player=Instantiate(playerPrefab,Vector3.zero,Quaternion.identity) as GameObject;
		player.GetComponent<Main>().setValues(278,0);
	}
}
