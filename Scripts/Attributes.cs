//using UnityEngine;
//using System.Collections;

public class Attributes{

	public int statPoints=0;
	public int level = 1;
	public int EXP=0;
	public int EXPtoLevel;

	private int baseHP = 100;
	private int baseMP = 100;
	private int baseEN = 100;
	private int HitPoints;
	private int ManaPoints;
	private int EnergyPoints;
	private int MaxHitPoints;
	private int MaxManaPoints;
	private int MaxEnergyPoints;
	private int strength;
	private int agility;
	private int intelligence;

	public void Recalculate(){
		MaxHP=calcHP();//recalculate HP when leveled;
		MaxMP=calcMP();//and MP;
		MaxEN=calcEN();//and EN,yeh, smartz.
		HP=MaxHP;
		MP=MaxMP;
		EN=MaxEN;
		EXPtoLevel=level*90;
	}
	public void LevelUp(){
		if(EXP>level*90){
			EXP=EXP-level*90;
			level++;
			statPoints+=5;
			STR++;
			AGI++;
			INT++;
			Recalculate();
		}
	}

	public int calcHP(){
		return baseHP+(int)(level*level)+(int)(strength*5);
	}
	public int calcMP(){
		return baseMP+(int)(level*level)+(int)(intelligence*4);
	}
	public int calcEN(){
		return baseEN+(int)(level*level)+(int)(agility*3);
	}
	public int MaxHP{
		get{return MaxHitPoints;}
		set{MaxHitPoints = value;}
	}
	public int MaxMP{
		get{return MaxManaPoints;}
		set{MaxManaPoints = value;}
	}
	public int MaxEN{
		get{return MaxEnergyPoints;}
		set{MaxEnergyPoints = value;}
	}
	public int HP{
		get{return HitPoints;}
		set{HitPoints = value;}
	}
	public int MP{
		get{return ManaPoints;}
		set{ManaPoints = value;}
	}
	public int EN{
		get{return EnergyPoints;}
		set{EnergyPoints = value;}
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
}
