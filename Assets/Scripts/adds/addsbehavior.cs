using UnityEngine;
using System.Collections;

public abstract class addsbehavior : GameObjBehavior {
	public player pl;
	// Use this for initialization
	void Start () {
		this.pl=GameObject.FindGameObjectWithTag("Player").GetComponent("player") as player;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if(other.tag=="Player"){
			Adds();
			pl=other.gameObject.GetComponent<player>();
			pl.playmusic(2);
			pl.audio.PlayOneShot(pl.getadd);
			Destroy(this.gameObject);
		}
	}
	
	override public void Bombed(){
	//Debug.Log("bünti");
	gameBehavior game=GameObject.FindGameObjectWithTag("prop").GetComponent<prop>().getGame();	
	game.AddEnemy(this.transform.position);
		Destroy(this.gameObject);
	}
	abstract public void Adds();
}
