using UnityEngine;
using System.Collections;

public class addbombthrough : addsbehavior {
	void Update () {
	
	}
	override public void Adds ()
	{
		if((pl.playerData["bombthrough"]+pl.adds["bombthrough"])<1){
		this.pl.adds["bombthrough"]=1;
		}else pl.score+=1000;	
	}
}