using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {
	public float timer=3f;
	public bool trigger;
	public float range;
	public ArrayList flames;
	public GameObject explode;
	public GameObject flame;
	public player p;
	public bool det;
	public bool killPlayer;
	// Use this for initialization
	void Start () {
		this.p=GameObject.FindGameObjectWithTag("Player").GetComponent("player") as player;
		
	this.trigger=((p.playerData["trigger"] + p.adds["trigger"]+p.playerDonate["trigger"])>0?true:false);
		this.explode=Resources.Load("bombs/explode/explode") as GameObject;
		this.range=p.playerData["range"]+p.adds["range"]+p.playerDonate["range"];
		this.flames=new ArrayList();
		this.det=false;
		
	}
	
	// Update is called once per frame
	void Update () {
		this.timer-=Time.deltaTime;
		if(this.timer<=0&&this.flames.Count<2&& !this.trigger){
			
		Det();
		}
	}
	public void Det(){
		if(this.det)return;
		this.det=true;
		for(int i=0;i<360;i+=90){
				Quaternion rot=Quaternion.identity;
				
				this.flame=Instantiate(this.explode,this.transform.position,rot) as GameObject;
				this.flame.transform.Rotate(0,i,0);
				ParticleEmitter f=this.flame.GetComponent("ParticleEmitter") as ParticleEmitter;
				f.localVelocity=new Vector3(0,0,this.range);
		//		this.flames.Add(this.flame);
			}
		this.flame=Instantiate(this.explode,this.transform.position,Quaternion.identity) as GameObject;
				this.flame.transform.Rotate(-90,0,0);
				ParticleEmitter g=this.flame.GetComponent("ParticleEmitter") as ParticleEmitter;
				g.localVelocity=new Vector3(0,0,1);
		//		
		if(killPlayer){player p=GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
			p.Bombed();
			p.canbomb=true;	
		}
		Destroy(this.gameObject,1);
		//p.bombs.Remove(this.gameObject);
	}
	void OnTriggerStay(Collider hit) {
		if(hit.tag=="Player") killPlayer=true;
	}
	void OnTriggerExit(Collider hit) {
		if(hit.tag=="Player") killPlayer=false;
	}
}
