using UnityEngine;
using System.Collections;

public class addbombprof : addsbehavior {
	void Update () {
	
	}
	override public void Adds ()
	{
		if((pl.playerData["bombprof"]+pl.adds["bombprof"])<1){
		this.pl.adds["bombprof"]=1;
		this.pl.gameObject.layer=9;
		}else pl.score+=1000;	
	}
}