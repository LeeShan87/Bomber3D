using UnityEngine;
using System.Collections;

public class addspeed : addsbehavior {
	void Update () {
	
	}
	override public void Adds ()
	{
		//this.pl.adds["speed"]=this.pl.adds["speed"]+3;
		if((GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMotor>().movement.maxForwardSpeed)<10){
		GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMotor>().movement.maxForwardSpeed+=3;
		}else pl.score+=1000;
	}
}