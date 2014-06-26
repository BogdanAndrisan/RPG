//using UnityEngine;
//using System.Collections;

public class Attributes{

	public int statPoints=0;
	public int level = 1;
	public int EXP=0;

	private int baseHP = 100;
	private int baseMP = 100;
	private int baseEN = 100;
	private int HP;
	private int MP;
	private int EN;
	private int strength;
	private int agility;
	private int intelligence;
	public int calcHP(){
		return HP=baseHP+(int)(level*level)+(int)(strength*5);
	}
	public int calcMP(){
		return MP=baseMP+(int)(level*level)+(int)(intelligence*4);
	}
	public int calcEN(){
		return EN=baseEN+(int)(level*level)+(int)(agility*3);
	}
	public int getHP(){
		return HP;
	}
	public int getMP(){
		return MP;
	}
	public int getEN(){
		return EN;
	}
	public void setHP(int HP){
		this.HP=HP;
	}
	public void setMP(int MP){
		this.MP=MP;
	}
	public void setEN(int EN){
		this.EN=EN;
	}
	public int STR{
		get{return strength;}
		set{strength = value;}
	}
	public int AGI{
		get{return agility;}
		set{agility = value;}
	}
	public int INT{
		get{return intelligence;}
		set{intelligence = value;}
	}
	public void Recalculate(){
		calcHP();//recalculate HP when leveled;
		calcMP();//and MP;
		calcEN();//and EN,yeh, smartz.
	}
	public void LevelUp(){
		if(EXP>level*90){
			EXP=EXP-level*90;
			level++;
			statPoints+=5;
			STR++;
			AGI++;
			INT++;
			calcHP();//recalculate HP when leveled;
			calcMP();//and MP;
			calcEN();//and EN,yeh, smartz.
		}
	}
}
