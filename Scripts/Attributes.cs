//using UnityEngine;
//using System.Collections;

public class Attributes{
	const int baseHP = 100;
	const int baseMP = 100;
	const int baseEN = 100;
	public int statPoints=0;
	public int level = 1;
	public int EXP=0;
	public int HP;
	public int MP;
	public int EN;
	public int strength;
	public int agility;
	public int intelligence;
	public int getHP(){
		return HP=baseHP+(int)(level*level)+(int)(strength*5);
	}
	public void LevelUp(){
		if(this.EXP>this.level*90){
			this.EXP=this.EXP-level*90;
			this.level++;
			this.statPoints+=5;
			this.strength+=2;
			this.HP=this.getHP();//recalculate HP when leveled.
		}
	}
}
