using UnityEngine;
using System.Collections;

public class addrange : addsbehavior {
	void Update () {
	
	}
	override public void Adds ()
	{
		if((pl.playerData["range"]+pl.adds["range"])<7){
		this.pl.adds["range"]=this.pl.adds["range"]+1;
		}else pl.score+=1000;
	}
}