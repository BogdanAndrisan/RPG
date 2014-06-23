//using UnityEngine;
//using System.Collections;

public class Attributes{
	const int baseHP = 100;
	const int baseMP = 100;
	const int baseEN = 100;
	public int level = 1;
	public int EXP;
	public int HP;
	public int MP;
	public int EN;
	public int strength;
	public int agility;
	public int intelligence;
	public int getHP(){
		return HP=baseHP+(int)(level^2)+(int)(strength*5);
	}
}
