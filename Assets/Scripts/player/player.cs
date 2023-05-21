using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class player : GameObjBehavior {
	public string playerName;
	//public int level;
	public int life;
	public Dictionary<string,int> playerData;
	public bool started;//ezt majd törölni kell
	public bool canbomb;
	public GameObject bombs;
	public Vector3 startPos;
	public Object[] bombtypes;
	public float timer;
	public System.DateTime time;
	public gameBehavior init;
	public int score=0;
	public int hiscore=0;
	public Transform cam;
	public Dictionary<string,int> adds;
	public Transform rot;
	public Vector3 lastpos;
//	CharacterController controller;
	public Vector3 moveDirection;
	//public portal portal;
	public data data;	
	public bool isdeath=false;
	public string host;
	public bool inobject;
	public bool soundon;
	public bool testmode=false;
	public bool ismapmode;
	public AudioSource activesound;
	public AudioClip move;
	public AudioClip deathsound;
	public AudioClip getadd;
	public AudioClip gameover;
	public Dictionary<string,int> playerDonate;
	
	// Use this for initialization
	/*public IEnumerator getPlayerData(){
		yield return data.getPlayerData();
		playerData=data.playerData;
	}
	public IEnumerator savePlayerData(string attrib="", int val=0){
	yield return data.savePlayerData(attrib,val);
	}	
	 */
	void Awake(){
		DontDestroyOnLoad(this.gameObject);
    	DontDestroyOnLoad(GameObject.FindGameObjectWithTag("minimap").gameObject);
		data=GetComponent<data>();
	}
	IEnumerator Start () {
		initAdds();
		cam= GameObject.FindGameObjectWithTag("minimap").transform;
		this.startPos=this.transform.position;
		this.bombtypes=Resources.LoadAll("bombs");
		this.bombs=new GameObject();
		this.bombs.name="bombs";
		DontDestroyOnLoad(bombs);
		yield return StartCoroutine(data.getPlayerData());
		Application.LoadLevel("start");
		playmusic(0);
	}
	void mapmode(){
		ismapmode=!ismapmode;
		Rect rect= cam.gameObject.GetComponent<Camera>().rect;
		cam.gameObject.GetComponent<Camera>().rect=new Rect(0.8f-rect.x,0,1.2f-rect.width,1.3f-rect.height);
		this.transform.rotation=Quaternion.identity;
		GetComponent<MouseLook>().enabled=!GetComponent<MouseLook>().enabled;
	}
	// Update is called once per frame
	IEnumerator bombadd(){
		if(canbomb){
		canbomb=false;
		if(this.bombs.transform.GetChildCount()<(this.playerData["bombs"]+this.adds["bombs"])){
			GameObject bomb=Instantiate(this.bombtypes[0],new Vector3((Mathf.Round(this.transform.position.x)),1,(Mathf.Round( this.transform.position.z))),Quaternion.identity) as GameObject;
			bomb.transform.parent=bombs.transform;
		}
		}
		yield return new WaitForSeconds(.1f);
		if(!inobject)canbomb=true;
		
	}
	void Update () {
		
/*		Vector3 dir=GetComponent<CharacterMotor>().inputMoveDirection;
		if(dir.x!=dir.z)
		if(Mathf.Abs(dir.x)<Mathf.Abs(dir.z)){
		float relx=transform.position.x-(int)transform.position.x;
		if((Mathf.Abs( dir.normalized.z)<.05f||Mathf.Abs( dir.normalized.z)>.95f)&&(relx<.45f||relx>.55f))transform.position=new Vector3(Mathf.Round(transform.position.x),transform.position.y,transform.position.z);
		}else {float relz=transform.position.z-(int)transform.position.z;
		if((Mathf.Abs( dir.normalized.x)<.05f||Mathf.Abs( dir.normalized.x)>.95f)&&(relz<.45f||relz>.55f))transform.position=new Vector3(transform.position.x,transform.position.y,Mathf.Round(transform.position.z));
		}*/
		//if(Input.GetKeyDown("1"))GetComponentInChildren<playmusic>().play(1);//GetComponent<CharacterMotor>().movement.maxForwardSpeed++;
		//if(Input.GetKeyDown("2"))GetComponentInChildren<playmusic>().play(2);//GetComponent<CharacterMotor>().movement.maxForwardSpeed--;
		//if(Input.GetKeyDown("3"))GetComponentInChildren<playmusic>().play(-1);
		if(Input.GetKeyDown("m")) mapmode();
		this.cam.position=new Vector3(this.transform.position.x,20,this.transform.position.z);
		this.cam.rotation=Quaternion.Euler(90f,this.transform.localRotation.eulerAngles.y,0f);
		if((Input.GetKey("q")||Input.GetMouseButton(0)||Input.GetKey("space"))){
			StartCoroutine(bombadd());
		
		}
		if((Input.GetKeyDown("e")||Input.GetMouseButtonDown(1)||Input.GetKeyDown("left ctrl"))&&((this.playerData["trigger"]+this.adds["trigger"]+this.playerDonate["trigger"])>0)){
			if(this.bombs.transform.GetChildCount()>0){
				bombs.transform.GetChild(0).gameObject.GetComponent<bomb>().Det();
				}
			}
		if(Input.GetKeyDown("escape"))GetComponent<gui>().showmenu=!GetComponent<gui>().showmenu;
		if(Input.GetKeyDown("p"))Time.timeScale=1f-Time.timeScale;
		if(Input.GetAxis("Vertical")!=0||Input.GetAxis("Horizontal")!=0) {animation.Play("walk");
			if(!soundon){StartCoroutine( playstep());soundon=true;}
			
		}
		else animation.Play("stay");
		if(this.transform.position.y<0f)this.transform.position=new Vector3(this.transform.position.x,0.8f,this.transform.position.z);
		if(this.transform.position.y>3f)this.transform.position=new Vector3(this.transform.position.x,0.8f,this.transform.position.z);
		
		if(init){
		if(this.transform.position.z>init.z-1f)this.transform.position=new Vector3(this.transform.position.x,this.transform.position.y,init.z-1f);
		if(this.transform.position.z<1f)this.transform.position=new Vector3(this.transform.position.x,this.transform.position.y,1f);
		if(this.transform.position.x<1f)this.transform.position=new Vector3(1f,this.transform.position.y,this.transform.position.z);
		if(this.transform.position.x>init.x-1f)this.transform.position=new Vector3(init.x-1f,this.transform.position.y,this.transform.position.z);
		}
		if(Time.timeScale!=0)
			if(Input.mousePosition.y>Screen.height-60&&Input.mousePosition.y<Screen.height-30
			&&Input.mousePosition.x>10&&Input.mousePosition.x<220
			)canbomb=false;
		//else canbomb=true;
	}
	IEnumerator playstep(){
		audio.PlayOneShot(move);
		yield return new WaitForSeconds(.3f); 
		soundon=false;	
		
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="portal"){ GetComponent<gui>().portal=other.gameObject.GetComponent<portal>();}
		canbomb=false;
		StartCoroutine( inobj());
	}
	IEnumerator inobj(){
		if(!inobject){inobject=true;
		yield return new WaitForSeconds(3f);
		inobject=false;}
	}
	void OnTriggerExit(Collider other) {
		switch (other.tag){
		case "bomb":{other.isTrigger=false; break;}
		case "brig":{other.isTrigger=false; break;}
		case "portal":{GetComponent<gui>().portal=null;GetComponent<MouseLook>().enabled=true;break;}
		}
		inobject=false;
	}
	void OnCollisionEnter(Collision hit) {
		if(hit.gameObject.tag=="enemy"){death();}
	}
	void OnTriggerStay(Collider other){
		if(other.tag!="Untagged"||other.tag!="wall"||other.tag!="enemy"){
			StartCoroutine( inobj());
			canbomb=false;
		}
	}
	void OnControllerColliderHit (ControllerColliderHit hit) {
		if((hit.gameObject.tag=="brig"&& (this.adds["wallthrough"]+this.playerData["wallthrough"])>0)
			||(hit.gameObject.tag=="bomb"&& (this.adds["bombthrough"]+this.playerData["bombthrough"])>0)){
			hit.gameObject.collider.isTrigger=true;
		}
		if(hit.gameObject.tag=="enemy")death();
		
	}
	
	override public void Bombed(){
		if((adds["bombprof"]+playerData["bombprof"])==0)death();
	}
	
	public void initAdds(){
		this.adds=new Dictionary<string, int>();
		this.adds.Add("bombs",0);
		this.adds.Add("range",0);
		//this.adds.Add("speed",0);
		this.adds.Add("trigger",0);
		this.adds.Add("wallthrough",0);
		this.adds.Add("bombthrough",0);
		this.adds.Add("bombprof",0);
		if(started){//GetComponent<CharacterMotor>().movement.maxForwardSpeed=playerData["speed"];
		if((this.adds["bombprof"]+playerData["bombprof"])==0)this.gameObject.layer=0;}
		}

	public void death(){
		StartCoroutine( GameObject.FindGameObjectWithTag("prop").GetComponent<prop>().getGame().death());	
	this.canbomb=true;
	}
	public void playmusic(int i){
		GetComponentInChildren<playmusic>().play(i);
	}
}
