using UnityEngine;
using System.Collections;

public class enemyBehavior : GameObjBehavior {
	public float speed=1f;
	public bool see;
	public bool toPlayer;
	public bool aggressiv;
	public bool wallthrough;
	public int point;
	public Vector3 moveDirection;
	public Rigidbody controller;
	public float maxVelocityChange=1f;
	public Vector3 target;
	public Vector3 velocityChange;
	public Vector3 startpos;
	public gameBehavior game;
	public bool death;
	
	public void Awake(){
		this.moveDirection=this.transform.forward;
		this.controller = this.rigidbody;
		startpos=this.transform.position;
		game=GameObject.FindGameObjectWithTag("prop").GetComponent<prop>().getGame();
	}

	
	
	// Update is called once per frame
	public void Update () {
		Move();
		if(game)if(this.transform.position.z>game.z||this.transform.position.z<0f||this.transform.position.x<0f||this.transform.position.x>game.x)this.transform.position=startpos;
		
	}
	void Move(){
		moveDirection=this.transform.forward;
		RaycastHit hit;
		if(this.see){
			if(!toPlayer){
				if(Physics.Raycast(this.transform.position,this.transform.right,out hit,10f)){if(hit.transform.tag=="Player"){ this.transform.Rotate(0,90,0);this.toPlayer=true;}}
		if(Physics.Raycast(this.transform.position,-this.transform.right,out hit,10f)){if(hit.transform.tag=="Player"){ this.transform.Rotate(0,-90,0);this.toPlayer=true;}}
			}else toPlayer=false;
		}
		if(Physics.Raycast(this.transform.position,this.transform.forward,out hit,0.55f)){
			if(hit.transform.tag=="wall" || (hit.transform.tag=="brig"&&!this.wallthrough) 
			|| hit.transform.tag=="bomb"||hit.transform.tag=="enemy"){
			if(Random.Range(0,2)==1) this.transform.Rotate(0,90,0);
				else this.transform.Rotate(0,-90,0);
			}
		}
	    this.target=this.transform.forward * this.speed;
		
		velocityChange = (this.target - controller.velocity);
		velocityChange.x = Mathf.Clamp(velocityChange.x, -this.speed, this.speed);
		velocityChange.z = Mathf.Clamp(velocityChange.z, -this.speed, this.speed);
		velocityChange.y = 0;
		
        controller.AddForce(velocityChange, ForceMode.VelocityChange);
	}
	void OnCollisionEnter(Collision hit) {
		if(hit.gameObject.tag=="Player"){this.transform.Rotate(0,90,0); hit.gameObject.GetComponent<player>().death();}
		if(hit.gameObject.tag=="enemy"){this.transform.Rotate(0,90,0);}
	}
	
	void OnCollisionStay(Collision hit) {
		if(hit.gameObject.tag=="wall" || (hit.gameObject.tag=="brig"&&!this.wallthrough) 
			|| hit.gameObject.tag=="bomb"||hit.gameObject.tag=="enemy"){
			if(Random.Range(0,2)==1) this.transform.Rotate(0,90,0);
				else this.transform.Rotate(0,-90,0);
		}
		
		if((hit.gameObject.tag=="brig"&&this.wallthrough))hit.gameObject.collider.isTrigger=true;
		//if(hit.gameObject.tag=="Player"){this.transform.Rotate(0,90,0); hit.gameObject.GetComponent<player>().death();}
	}
	void OnTriggerEnter(Collider other) {
		//this.gameObject.transform.parent.gameObject
			
		if(other.tag=="enemy"){
			other.isTrigger=true;
		}
	}
	void OnTriggerExit(Collider other) {
		if(other.tag=="enemy"||other.tag=="brig")
		other.isTrigger=false;
	}

   override public void Bombed(){
	if (!death){
			death=true;
		player p=GameObject.FindGameObjectWithTag("Player").GetComponent("player") as player;
		p.score+=this.point;
		if(p.score>p.hiscore)p.hiscore=p.score;
		Destroy(this.gameObject);
	}
	}	
}
