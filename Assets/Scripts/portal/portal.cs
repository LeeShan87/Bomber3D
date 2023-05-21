using UnityEngine;
using System.Collections;

public class portal : GameObjBehavior {
	public Color[] ok;
	public Color[] notok;
	public bool isok;
	public ParticleAnimator anim;
	public string mess;
	public prop prop;
	public player player;
	public string game;
	public bool entered=false;
	public int level=1;
	public int minLevel=1;
	public int maxLevel=1;
	public int x;
	public int z;
	public string description;
	public string adds;
	public int val;
	public bool enter=false;
	// Use this for initialization
	void Start () {
		this.prop=GameObject.FindGameObjectWithTag("prop").GetComponent<prop>();
		this.player=GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
		this.anim= this.gameObject.GetComponent<ParticleAnimator>();
		this.notok= this.anim.colorAnimation;
		this.ok=new Color[5];
		this.ok[0]=new Color(0.929f, 1.000f, 0.000f, 0.055f);
		this.ok[1]=new Color(0.000f, 1.000f, 0.624f, 0.706f);
		this.ok[2]=new Color(0.000f, 1.000f, 0.459f, 1.000f);
		this.ok[3]=new Color(0.000f, 1.000f, 1.000f, 0.706f);
		this.ok[4]=new Color(0.063f, 0.678f, 0.000f, 0.039f);
				this.isok=false;
	
			chColor();
		/*this.ok=anim.colorAnimation;
		new Color()
		foreach(Color c in ok){
			print(c);
		}*/
	}
	
	// Update is called once per frame
	public void chColor(string ok=""){
		if(ok==""){
		if (isok) {//this.isok=false; 
				this.anim.colorAnimation=this.ok; }
		else
		{//this.isok=true; 
				this.anim.colorAnimation=this.notok;}
		}else if(ok=="ok"){this.isok=true; 
			this.anim.colorAnimation=this.ok; }
	}
	public override void Bombed ()
	{
		//Debug.Log("nagyon nagy bünt...");
		gameBehavior game=GameObject.FindGameObjectWithTag("prop").GetComponent<prop>().getGame();	
		if(game)for(int i=0;i<3;i++){
		game.AddEnemy(this.transform.position);
		}
		
	}
	void Update () {
		if(!IsInvoking("isemit")&&GetComponent<ParticleEmitter>().emit==false)
			Invoke("isemit",1f);
		if(!isok)if((this.player.playerData["level"]>=this.minLevel
			//&&(!GameObject.FindGameObjectWithTag("enemys")||!GameObject.FindGameObjectWithTag("enemy"))
			)
			)
				chColor("ok");
	
	}
	bool isemit(){
		if(GetComponent<ParticleEmitter>().emit==false){GetComponent<ParticleEmitter>().emit=true;return false;}
		else
		return true;
	}
	void OnCollisionStay(Collision hit) {
		if(hit.collider.tag=="brig") GetComponent<ParticleEmitter>().emit=false;
	}
	void OnTriggerStay(Collider other) {
		if(other.tag=="brig") GetComponent<ParticleEmitter>().emit=false;
	if(other.tag=="Player"){
			switch(this.game){
			case "classic":{if(!entered && isok && enter){GameObject.FindGameObjectWithTag("init").GetComponent<init>().classic(); } break;}
			case "start":{if(!entered && isok && enter){GameObject.FindGameObjectWithTag("init").GetComponent<init>().start();  } break;}			
			case "multi":{break;}
			default:{getGame(this.game);break;}
			}
				
		}
	}
	void OnParticleCollision(GameObject other) {
		
	}
	void getGame(string game){
		if(!entered && !isok && prop.getGame())
			if(prop.getGame().enemyk.transform.GetChildCount()!=0)this.description=GameObject.FindGameObjectWithTag("Player").GetComponent<loadi18n>().i18n["stillenemy"];
				{if(!entered && isok && enter){
					if(this.prop.getGame())
						this.prop.getGame().newGame();
						else {this.prop.addGame(game);
					this.prop.minlevel=this.minLevel;
					this.prop.level=level;this.
						prop.maxLevel=this.maxLevel;
					prop.adds=this.adds;
					prop.startlevel=0;
					prop.endlevel=maxLevel-level;
					prop.val=this.val;prop.x=this.x;prop.z=this.z;}
					this.entered=true;}}
	}
}
