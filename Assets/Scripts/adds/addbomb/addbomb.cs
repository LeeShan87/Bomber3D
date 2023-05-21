using UnityEngine;
using System.Collections;

public class addbomb : addsbehavior {
	public int adds;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
	
	}
	override public void Adds ()
	{
		if(7>(pl.playerData["bombs"]+pl.adds["bombs"]))
		this.pl.adds["bombs"]=this.pl.adds["bombs"]+1;
		else pl.score+=1000;
		//this.pl.adds["bombprof"]=1;
	}
}
