using UnityEngine;
using System.Collections;

public abstract class gameBehavior : MonoBehaviour
{
	public prop prop;
	public string name;
	
	public int x;
	public int z;
	public int diff;
	public string[,] poss;
	public GameObject enemyk;
	public GameObject falak;
	public GameObject teglak;
	public GameObject addok;
	public GameObject portals;
	//public ArrayList enemyk;
	public int enemys;
	public Object[] walls;
	public Object[] enemy;
	public Object[] players;
	public Object[] adds;
	public float timer;
	public bool loaded;
	public bool isdeath;
	
	public void Awake(){
		this.prop=GameObject.FindGameObjectWithTag("prop").GetComponent<prop>();
		
		player p=GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
		p.init=this.prop.getGame();
		p.life=p.playerData["life"]+p.playerDonate["life"];
		this.enemy=Resources.LoadAll("enemies");
		this.walls=Resources.LoadAll("walls");
		this.adds=Resources.LoadAll("adds");
		p.initAdds();
			
	}
	public abstract void Game();
	public abstract bool isGameEnd();
	public abstract IEnumerator death();

	public void resetLevel(){
		Destroy(this.enemyk);
		Destroy(this.teglak);
		Destroy(this.falak);
		constr(false);
		Game();
	}
	public void newGame(){
		//resetLevel();
		player p=GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
		StartCoroutine( GameObject.FindGameObjectWithTag("Player").GetComponent<data>().savePlayerData());
		p.canbomb=true;
		p.playmusic(1);
		diff=prop.level>this.enemy.Length?this.enemy.Length:prop.level;
		constr();
		Game();
		//GameObject.FindGameObjectWithTag("Player").GetComponent<player>().level=this.prop.level;	
	}
	public void constr(bool newgame=true){
		Destroy(this.enemyk);
		Destroy(this.teglak);
		Destroy(this.falak);
		Destroy(this.addok);
		Destroy(this.portals);
		
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("bomb"))Destroy(obj);
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("explode"))Destroy(obj);
		if(newgame){
		this.x=prop.x;
		this.z=prop.z;
			prop.startlevel++;
		prop.level++;
		this.enemys=(int)((x>z?x:z)/4)+diff;//(int)((x>z?x:z)/4)+
		setPoss(this.x,this.z);}
		GameObject p=GameObject.FindGameObjectWithTag("Player");
		StartCoroutine(p.GetComponent<gui>().startScreen());
		this.timer=x*z/2*(p.GetComponent<player>().time>System.DateTime.Now?2:1);
		this.falak=new GameObject();
		this.falak.name="falak";
		this.teglak=new GameObject();
		this.teglak.name="teglak";
		this.enemyk=new GameObject();
		this.enemyk.name="enemys";
		this.enemyk.tag="enemys";	
		this.addok=new GameObject();
		this.addok.name="addok";
		this.portals=new GameObject();
		this.portals.name="portals";
		//this.enemyk=new ArrayList();
		//constr(prop.x,prop.z,(prop.level>this.enemy.Length?this.enemy.Length:prop.level));
		
		//Vector3 pos=new Vector3((float)x/2,-0.5f,(float)z/2);
		//Quaternion rot=Quaternion.identity;
		//GameObject flour=(GameObject)Instantiate(this.walls[0],pos,rot) as GameObject;
		//flour.transform.localScale=new Vector3(this.x,1f,this.z);
		//flour.transform.parent=this.falak.transform;
		
		
		
		initobj();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.timer-=Time.deltaTime;
		if(this.enemyk&&this.enemyk.transform.GetChildCount()==0){if(GameObject.FindGameObjectWithTag("portal"))GameObject.FindGameObjectWithTag("portal").GetComponent<portal>().chColor("ok");}
	}
	
	public void setPoss(int x, int z){
		poss= new string[x,z];
		int e=this.enemys;
		int szabhely=((int)((x-2)*(z-2))/2)-e;
		int r;
		for(int i=0;i<x;i++){
			for(int j=0;j<z;j++){
				if(i==0 || j==0||i==x-1||j==z-1){
					poss[i,j]="wall";continue;}
				if(i==1&&j==1){poss[i,j]="player";continue;}
				if(i%2==0 && j%2==0){poss[i,j]="wall";continue;}
				r=Random.Range(0,100);
				if(i>5&&j>5)if(r>70 && e>0){poss[i,j]="enemy";e--;continue;}
				if(!(i==1&&j==2)&&!(i==2&&j==1))if(Random.Range(0,szabhely)>szabhely*0.8){
					poss[i,j]="tegla";continue;}
			}
		}
		this.poss= poss;
	}
	public void initobj(){
		//setPoss(x,z);
	
		Quaternion rot=Quaternion.identity;
		Vector3 pos=new Vector3();
//		int szabhely=((int)((x-2)*(z-2))/2);
		//Debug.Log(this.diff);
		for(int i=0;i<x;i++){
			for(int j=0;j<z;j++){
			switch (this.poss[i,j]){
				case "wall":{
					pos.Set(i,1f,j);
					GameObject g=Instantiate(this.walls[0],pos,rot) as GameObject;
					g.transform.parent=this.falak.transform;
					break;
				}	
					case "enemy":{
					pos.Set(i,1f,j);
					AddEnemy(pos);
					break;
				}
						case "player":{
					player p= GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
					pos.Set(i,1.05f,j);
						p.startPos=pos;
						p.transform.position=p.startPos;
					//Instantiate(this.players[0],pos,rot);
					break;
				}
							case "tegla":{
					pos.Set(i,1f,j);
					GameObject g=Instantiate(this.walls[1],pos,rot) as GameObject;
					g.transform.parent=this.teglak.transform;
					break;}
					
			}
		}
			
	}
		//if(!GameObject.FindGameObjectWithTag("add")){pos.Set(x-2+0.5f,1f,z-3+0.5f);Instantiate(this.walls[2],pos,rot);Instantiate(this.adds[(prop.level-1)%this.adds.Length],pos,rot);}
		//if(!GameObject.FindGameObjectWithTag("portal")){pos.Set(x-2+0.5f,1f,z-2+0.5f);Instantiate(this.walls[2],pos,rot);{GameObject portal= Instantiate(Resources.Load("portal"),pos,rot) as GameObject;portal.GetComponent<portal>().game=this.name;}}
		
}
	public void AddPortal(Vector3 pos){
		GameObject portal= Instantiate(Resources.Load("portal"),pos,Quaternion.identity) as GameObject;portal.GetComponent<portal>().game=this.name;
		portal.transform.parent=this.portals.transform;
	}
	public void AddAdd(Vector3 pos,string id=""){
		GameObject ad;
		//if(!GameObject.FindGameObjectWithTag("add")){
		switch(id){
			case "bombs":{ ad =Instantiate(this.adds[0],pos,Quaternion.identity) as GameObject;break;}
			case "range":{ ad =Instantiate(this.adds[1],pos,Quaternion.identity) as GameObject;break;}
			case "speed":{ ad =Instantiate(this.adds[2],pos,Quaternion.identity) as GameObject;break;}
			case "trigger":{ ad =Instantiate(this.adds[3],pos,Quaternion.identity) as GameObject;break;}
			case "wallthrough":{ ad =Instantiate(this.adds[4],pos,Quaternion.identity) as GameObject;break;}
			case "bombthrough":{ ad =Instantiate(this.adds[5],pos,Quaternion.identity) as GameObject;break;}
			case "bombprof":{ ad =Instantiate(this.adds[6],pos,Quaternion.identity) as GameObject;break;}
			case "life":{ ad =Instantiate(this.adds[7],pos,Quaternion.identity) as GameObject;break;}
		default: {ad =Instantiate(this.adds[(prop.level-1)%this.adds.Length],pos,Quaternion.identity) as GameObject;break;}
		}
		ad.transform.parent=this.addok.transform;
		//}
	}
	public void AddEnemy(Vector3 pos){
		GameObject g=Instantiate(this.enemy[Random.Range(0,this.diff)],pos,Quaternion.identity) as GameObject;
					g.transform.parent= this.enemyk.transform;
					
	}
	void OnDestroy () {
				Destroy(this.enemyk);
		Destroy(this.teglak);
		Destroy(this.falak);
		Destroy(this.addok);
		Destroy(this.portals);
		
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("bomb"))Destroy(obj);
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("explode"))Destroy(obj);

	}
}

