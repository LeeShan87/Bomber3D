using UnityEngine;
using System.Collections;

public class init : MonoBehaviour
{
	public GameObject portals;
	public GameObject kenelobjs;
	public GameObject addobj;
	public GameObject brig;
	public Object[] wall;
	public Object[] enemy;
	public Object[] adds;
	public Object portal;
	public loadi18n i18n;
	public bool started;
		
	void Start ()
	{
		portal=Resources.Load("portalshrine");
		wall=Resources.LoadAll("walls");
		enemy=Resources.LoadAll("enemies");
		adds=Resources.LoadAll("adds");
		portals=new GameObject();
		portals.name="portals";
		//player p= GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
		//p.playmusic(0);
		//if(p.life<0)//p.audio.PlayOneShot(p.gameover);
		//p.life=p.playerData["life"];
		kenels();
		addobjs();
		brigs();
	}
	public void reset(){
		Destroy(portals);
		Destroy(kenelobjs);
		Destroy(brig);
		Destroy(addobj);
		portals=new GameObject();
		portals.name="portals";
		
	}
	public void start(){
		//player player=GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
		//player.transform.position=new Vector3(28f,1f,15f);
		//if(player.init) Destroy(player.init);
		reset();
		kenels();
		addobjs();
		brigs();
		
		//arena init
	/*	createPortalShrine(new Vector3(20f,-0.1f,20f),new Vector3(270,180,0),"arena",1,1,1,17,17,
			"desc_arena");
		
		//tilltheend init
		createPortalShrine(new Vector3(25f,-0.1f,20f),new Vector3(270,180,0),"tillTheEnd",1,1,1,29,17,"desc_tilltheend");
		//story init
		createPortalShrine(new Vector3(30f,-0.1f,20f),new Vector3(270,180,0),"classic",1,1,1,1,1,"desc_story");
		//classic init
		createPortalShrine(new Vector3(35f,-0.1f,20f),new Vector3(270,180,0),"classicgame",5,0,51,31,13,"desc_classic");
	*/	Debug.Log("init start end");
	}
	public void classic(){
		player player= GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
		player.transform.position=new Vector3(35f,1f,35f);
		if(player.init) Destroy(player.init);
		reset();
		kenels();
		addobjs();
		brigs();
		
		string desc="desc_storygame";
		//createPortalShrine(pos, rot,  gamename, minlevel, level, maxlevel, x, z, desc, adds=""){
		//story level1 init
		createPortalShrine(new Vector3(26f,-0.1f,31f),new Vector3(270,45,0),"story",1,1,3,15,15,desc,"bombs");
		//story level2 init
		createPortalShrine(new Vector3(31f,-0.1f,31f),new Vector3(270,0,0),"story",2,1,4,15,17,desc,"range");
		//story level3 init
		createPortalShrine(new Vector3(36f,-0.1f,31f),new Vector3(270,0,0),"story",3,1,5,15,17,desc,"bombs");
		//story level4 init
		createPortalShrine(new Vector3(41f,-0.1f,31f),new Vector3(270,0,0),"story",4,1,6,15,17,desc,"range");
		//story level5 init
		createPortalShrine(new Vector3(46f,-0.1f,31f),new Vector3(270,0,0),"story",5,2,6,17,17,desc,"speed");
		//story level6 init
		createPortalShrine(new Vector3(51f,-0.1f,31f),new Vector3(270,-45,0),"story",6,2,7,19,17,desc,"life");
		//story level7 init
		createPortalShrine(new Vector3(51f,-0.1f,36f),new Vector3(270,-90,0),"story",7,2,7,19,17,desc,"bombs");
		//story level8 init
		createPortalShrine(new Vector3(51f,-0.1f,41f),new Vector3(270,-90,0),"story",8,2,8,19,17,desc,"life");
		//story level9 init
		createPortalShrine(new Vector3(51f,-0.1f,46f),new Vector3(270,-90,0),"story",9,3,9,19,17,desc,"range");
		//story level10 init
		createPortalShrine(new Vector3(51f,-0.1f,51f),new Vector3(270,-90,0),"story",10,3,9,21,17,desc,"trigger");
		//story level11 init
		createPortalShrine(new Vector3(51f,-0.1f,56f),new Vector3(270,-135,0),"story",11,3,10,21,17,desc,"life");
		//story level12 init
		createPortalShrine(new Vector3(46f,-0.1f,56f),new Vector3(270,180,0),"story",12,3,11,21,17,desc,"bombs");
		//story level13 init
		createPortalShrine(new Vector3(41f,-0.1f,56f),new Vector3(270,180,0),"story",13,4,12,21,17,desc,"range");
		//story level14 init
		createPortalShrine(new Vector3(36f,-0.1f,56f),new Vector3(270,180,0),"story",14,4,12,21,19,desc,"wallthrough");
		//story level15 init
		createPortalShrine(new Vector3(31f,-0.1f,56f),new Vector3(270,180,0),"story",15,5,13,21,19,desc,"life");
		//story level16 init
		createPortalShrine(new Vector3(26f,-0.1f,56f),new Vector3(270,135,0),"story",16,5,14,21,19,desc,"bombs");
		//story level17 init
		createPortalShrine(new Vector3(26f,-0.1f,51f),new Vector3(270,90,0),"story",17,5,14,21,21,desc,"range");
		//story level18 init
		createPortalShrine(new Vector3(26f,-0.1f,46f),new Vector3(270,90,0),"story",18,6,15,21,21,desc,"bombthrough");
		//story level19 init
		createPortalShrine(new Vector3(26f,-0.1f,41f),new Vector3(270,90,0),"story",19,7,16,23,21,desc,"life");
		//story level20 init
		createPortalShrine(new Vector3(26f,-0.1f,36f),new Vector3(270,90,0),"story",20,8,18,25,25,desc,"bombprof");
		//start portal
		createPortalShrine(new Vector3(38f,-0.1f,45f),new Vector3(270,180,0),"start",1,1,1,1,1,"vissza a starthoz.","bombprof");
		
	}
	void Update(){
	/*	if(!started){
			start();
			if(GameObject.FindGameObjectWithTag("portal"))
				started=true;}*/
	}
	public void createPortalShrine(Vector3 pos, Vector3 rot, string gamename, int minlevel, int level, int maxlevel, int x, int z, string desc,string adds=""){
		GameObject portalobj=Instantiate(portal,pos,Quaternion.Euler(rot))as GameObject;
		portal portalsrp=portalobj.transform.GetChild(0).gameObject.GetComponent<portal>();
		portalsrp.game=gamename;
		portalsrp.minLevel=minlevel;
		portalsrp.level=level;
		portalsrp.maxLevel=maxlevel;
		portalsrp.x=x;portalsrp.z=z;
		portalsrp.description=desc;
		if(adds!=""){portalsrp.adds=adds;portalsrp.val=1;}
		if(adds=="speed"){portalsrp.adds=adds;portalsrp.val=3;}
		portalobj.transform.parent=portals.transform;
	}
	public GameObject createKenel(Vector3 pos,int enemynum){
		GameObject ret=new GameObject();
		GameObject g= Instantiate(wall[0],pos,Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x+1,pos.y,pos.z),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x+2,pos.y,pos.z),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x+3,pos.y,pos.z),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x+4,pos.y,pos.z),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x+4,pos.y,pos.z+1),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x+4,pos.y,pos.z+2),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x+4,pos.y,pos.z+3),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x+4,pos.y,pos.z+4),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x+3,pos.y,pos.z+4),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x+2,pos.y,pos.z+4),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x+1,pos.y,pos.z+4),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x,pos.y,pos.z+4),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x,pos.y,pos.z+3),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x,pos.y,pos.z+2),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[0],new Vector3(pos.x,pos.y,pos.z+1),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		g=Instantiate(wall[1],new Vector3(pos.x+2,pos.y,pos.z+1),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		
		g=Instantiate(enemy[enemynum],new Vector3(pos.x+1,pos.y,pos.z+1),Quaternion.identity)as GameObject;
		g.transform.parent=ret.transform;
		ret.name="kenel";
		return ret;
	}
	public void kenels(){
		 kenelobjs=new GameObject();
		kenelobjs.name="kenels";
		GameObject t;//=new GameObject();
		t=createKenel(new Vector3(-4,1,-5),0);
		t.transform.parent=kenelobjs.transform;
		t=createKenel(new Vector3(5,1,-5),1);
		t.transform.parent=kenelobjs.transform;
		t=createKenel(new Vector3(14,1,-5),2);
		t.transform.parent=kenelobjs.transform;
		t=createKenel(new Vector3(23,1,-5),3);
		t.transform.parent=kenelobjs.transform;
		t=createKenel(new Vector3(32,1,-5),4);
		t.transform.parent=kenelobjs.transform;
		t=createKenel(new Vector3(41,1,-5),5);
		t.transform.parent=kenelobjs.transform;
		t=createKenel(new Vector3(50,1,-5),6);
		t.transform.parent=kenelobjs.transform;
		
	}
	public void addobjs(){
		 addobj=new GameObject();
		addobj.name="adds";
		int pos=5;
		foreach(Object ob in adds){
			GameObject g=Instantiate(ob,new Vector3(-4,1,pos),Quaternion.identity)as GameObject;
			g.transform.parent=addobj.transform;
			pos+=3;
		}
	}
	public void brigs(){
		 brig=new GameObject();
		brig.name="brigs";
		for(int i=-8;i<-4;i++)
		for(int j=0;j<70;j++)
		if(Random.Range(0,10)>8)
		{
			GameObject g=Instantiate(wall[1],new Vector3(i,1,j),Quaternion.identity)as GameObject;
			g.transform.parent=brig.transform;
		}
		for(int i=-8;i<70;i++)
		for(int j=70;j<74;j++)
		if(Random.Range(0,10)>8)
		{
			GameObject g=Instantiate(wall[1],new Vector3(i,1,j),Quaternion.identity)as GameObject;
			g.transform.parent=brig.transform;
		}
		for(int i=70;i<74;i++)
		for(int j=0;j<70;j++)
		if(Random.Range(0,10)>7)
		{
			GameObject g=Instantiate(wall[1],new Vector3(i,1,j),Quaternion.identity)as GameObject;
			g.transform.parent=brig.transform;
		}
		
	}
}

