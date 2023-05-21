using UnityEngine;
using System.Collections;

public class brig : WallsObjBehavior {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	override public void Bombed(){
	Destroy(this.gameObject,1);
	}	
}
