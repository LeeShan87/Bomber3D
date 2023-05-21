using UnityEngine;
using System.Collections;

public class addwallthrough : addsbehavior {
	void Update () {
	
	}
	override public void Adds ()
	{
		if((pl.playerData["wallthrough"]+pl.adds["wallthrough"])<1){
		this.pl.adds["wallthrough"]=1;
		}else pl.score+=1000;
	}
}