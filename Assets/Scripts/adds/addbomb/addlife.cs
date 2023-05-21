using UnityEngine;
using System.Collections;

public class addlife : addsbehavior {

	override public void Adds ()
	{
		this.pl.life++;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
