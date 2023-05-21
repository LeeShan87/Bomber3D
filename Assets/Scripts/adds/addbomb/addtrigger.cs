using UnityEngine;
using System.Collections;

public class addtrigger : addsbehavior {
	void Update () {
	
	}
	override public void Adds ()
	{
		if((pl.playerData["trigger"]+pl.adds["trigger"])<1){
		this.pl.adds["trigger"]=this.pl.adds["trigger"]+1;
		}else pl.score+=1000;
	}
}