using UnityEngine;
using System.Collections;

public class explode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	Destroy(this.gameObject,1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//   void OnParticleCollision(GameObject other) {
      //  Debug.Log("exp");
		
//    }
	  void OnParticleCollision(GameObject other) {//void OnTriggerEnter(Collider other) {
		//Debug.Log(other.tag);
		//Debug.Log("expoldwe");
		switch(other.tag){
		case "Player":{
			player t=other.GetComponent("player") as player;
			if((t.adds["bombprof"]+t.playerData["bombprof"])==0) t.Bombed();break;}
		case "enemy":{
			enemyBehavior t=other.GetComponent("enemyBehavior") as enemyBehavior;
			t.Bombed();break;}
		case "brig":{
			brig t=other.GetComponent("brig") as brig;
			t.Bombed();break;}
		case "bomb":{
			bomb t=other.GetComponent("bomb") as bomb;
			t.Det();break;}
		case "add":{
			addsbehavior a=other.GetComponent("addsbehavior") as addsbehavior;
			if(!a.IsInvoking("Bombed"))a.Invoke("Bombed",1);break;
		}
			case "portal":{
			portal t=other.GetComponent("portal") as portal;
			if(!t.IsInvoking("Bombed"))t.Invoke("Bombed",1);break;}
		}
		
		
		
	}
}
