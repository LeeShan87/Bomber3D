using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {
	public player player;
	public loadi18n i18n;
	public leaderboard leader;
	public donate donatepacks;
	public sponsors sponsorsmembers;
	public prop prop;
	public Object[] images;
	public bool showinfo;
	public bool showmenu;
	public bool showloadgame;
	public bool showchangeLanguage;
	public bool showdonate;
	public bool showleaderboard;
	public bool showOption;
	public bool showStart;
	public bool showend;
	public bool showsponsors;
	public portal portal;
	public GameObject portals;
	private Vector2 scrollViewVector = Vector2.zero;
	public string[] scores;
	// Use player for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
		this.images=Resources.LoadAll("image");
		//i18n=GetComponent<loadi18n>();
		//leader= GetComponent<leaderboard>();
		//donatepacks=GetComponent<donate>();
		//sponsorsmembers=GetComponent<sponsors>();
		prop=GameObject.FindGameObjectWithTag("prop").GetComponent<prop>();
		//while(!GetComponent<leaderboard>().loaded);
		//scores=GetComponent<leaderboard>().scores;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public string timeToString(float time){
		string ret="";
		float t;
		//int days=(int)(time/(24*60*60))%24;
		//int hours=(int)(time/(60*60))%60;	
		int min=(int)(time/60)%60;
		int sec=(int)(time%60);
		/*int sec=(int)time%60;
		t=time/60;
		int min=(int)t%60;
		t=t/60;
		int hours=(int)(t%60);
		t=t/60;
		int days=(int)(t%24);*/
		//if(days>0)ret=""+days;
		//if(hours>0)ret=ret+" : "+hours;
		ret=ret+min+" : "+sec;//+"d:"+days+" h: "+hours+" m: "+min+" s: "+sec;
		return ret;
	}
	void screennew(bool v=true){
	showinfo=showmenu=showloadgame=showchangeLanguage=showdonate=showleaderboard= showOption=showStart=showend=showsponsors=false;
		GetComponent<MouseLook>().enabled=false;
		if(v){player.canbomb=false;
		Time.timeScale=0f;
		}
	}
	void screenend(){
	showinfo=showmenu=showloadgame=showchangeLanguage=showdonate=showleaderboard= showOption=showStart=showend=showsponsors=false;
		player.canbomb=true;
		GetComponent<MouseLook>().enabled=true;
		Time.timeScale=1f;
		
	}
	void OnGUI(){
		//if(!player.ismapmode)player.GetComponent<MouseLook>().enabled=true;
		//if(player.costum==null)player.costum=GUI.skin.box;
		string[] texts;
			if (player.init) texts=new string[] { player.playerName, "bombs", 
				(player.playerData["bombs"]+player.adds["bombs"]- player.bombs.transform.GetChildCount()).ToString(),"time", 
				timeToString(player.init.timer),"point",player.score.ToString(),"hiscore",player.hiscore.ToString(),"life"
				,player.life.ToString(),"enemys",player.init.enemyk.transform.GetChildCount().ToString()
			};
			else texts=new string[] { player.playerName, "bombs", 
				(player.playerData["bombs"]+player.adds["bombs"]- player.bombs.transform.GetChildCount()).ToString(),"point",
				player.score.ToString(),"hiscore",player.hiscore.ToString(),"life"
				,player.life.ToString()
			};
			drawGuiInRow(10,10,0,20,"Box",texts);
		if(player.transform.GetChild(7).audio.mute){
			if(GUI.Button(new Rect(10,30,30,30),images[9]as Texture))
			player.playmusic(-1);}
			else{
			if(GUI.Button(new Rect(10,30,30,30),images[10]as Texture))
			player.playmusic(-1);}
			if(Time.timeScale==0f){
			if(GUI.Button(new Rect(40,30,30,30),images[11]as Texture)){
			Time.timeScale=1f;player.canbomb=!player.canbomb;}}
			else{
			if(GUI.Button(new Rect(40,30,30,30),images[12]as Texture)){
			Time.timeScale=0f;player.canbomb=!player.canbomb;}}
			
		if(GUI.Button(new Rect(130,30,50,30),"MENU"))menu ();
		if(portal){ portalScreen(portal.game,portal.minLevel,portal.description,portal.adds,portal.val);}
		if(showmenu)menu();
		if(showloadgame)loadgame();
		if(showOption) Option();	
		if(showStart) start();
		if(showend) end();
		if(player.time>System.DateTime.Now){
				System.TimeSpan tm=new System.TimeSpan(player.time.Ticks-System.DateTime.Now.Ticks);
				string str="Donate:"+tm.Days+":"+tm.Hours+":"+tm.Minutes+":"+tm.Seconds;
				GUI.Box(new Rect(210,30,str.Length*8+10,30),str);
				
			}	
		
	}
	public void drawGuiInRow(int x, int y, int offset, int height, string type,string[] content){
		int relx=x;
		int rely=y;
		
		switch (type){
		case "Box":{
			
			foreach(string desc in content){
			GUI.Box(new Rect(relx,rely,(desc.Length*8+10),height),desc);relx+=desc.Length*8+10+offset;
			}
			break;}
		case "Button":break;
		default:break;
		}
		
	}
	
	void portalScreen(string name="test", int level=1, string description="ez egy teszt", string adds="bombák", int val=1){
		screennew(false);
		//GetComponent<MouseLook>().enabled=false;
		GUI.BeginGroup(new Rect(60,60, Screen.width-120,Screen.height-120));
		GUI.Box(new Rect(0,0, Screen.width-120,Screen.height-120),"");
		GUI.Label(new Rect(10,10,60,20),getgamename( name));
		GUI.Label(new Rect(10,30,"minlevel".Length*8+10,20),"minlevel");
		GUI.Label(new Rect("minlevel".Length*8+20,30,20,20),level.ToString());
		if(adds!=""){GUI.Label(new Rect(10,50,"bonus".Length*8+10,20),"bonus");
		GUI.Label(new Rect("bonus".Length*8+20,50,adds.Length*8+10,20),adds);
		GUI.Label(new Rect("bonus".Length*8+20+adds.Length*8+10,50,60,20),val.ToString());}
		GUI.TextArea(new Rect(10,70,Screen.width-140,Screen.height-230),description);
		if(GUI.Button(new Rect(10,Screen.height-150,70,20),"ok")){ portal.enter=true;screenend();}
		if(player.init)if(GUI.Button(new Rect(80,Screen.height-150,70,20),"exit")){Destroy(player.init); GameObject.FindGameObjectWithTag("init").GetComponent<init>().start();screenend();}
		//GUI.Button(new Rect(90,Screen.height-150,70,20),"mégse");
		GUI.EndGroup();
		
	}
	public string getgamename(string name){
		switch(name){
		case "arena":return "Arena";
		case "classic":return "Story";
		case "story":return "Story";
		case "classicgame": return "Classic Game";
		case "start":return "Start";
		case "tillTheEnd":return "Till The End";
		default: return "No Name";
		}
	}
	public void menu(){
		screennew();	
		showmenu=true;
		GUI.BeginGroup(new Rect(60,60, Screen.width-120,Screen.height-120));
		GUI.Box(new Rect(0,0, Screen.width-120,Screen.height-120),"");
		if(GUI.Button(new Rect((int)(Screen.width-"loadgame".Length*8)/2-60,10,"loadgame".Length*8+10,20),"loadgame")){loadgame();}
		//if(GUI.Button(new Rect((int)(Screen.width-"changelang"].Length*8)/2-60,40,"changelang"].Length*8+10,20),"changelang"])){chageLanguage();}
		//if(GUI.Button(new Rect((int)(Screen.width-"Donate".Length*8)/2-60,70,"donate".Length*8+10,20),"Donate")){donate();}
		//if(GUI.Button(new Rect((int)(Screen.width-"LeaderBoard".Length*8)/2-60,100,"leaderboard".Length*8+10,20),"LeaderBoard")){leaderboard();}
		//if(GUI.Button(new Rect((int)(Screen.width-"fullsrceen"].Length*8)/2-60,130,"fullsrceen"].Length*8+10,20),"fullsrceen"])){Screen.fullScreen = !Screen.fullScreen;}
		if(GUI.Button(new Rect((int)(Screen.width-"Options".Length*8)/2-60,160,"Options".Length*8+10,20),"Options")){Option();}
		//if(GUI.Button(new Rect((int)(Screen.width-"Sponsors:".Length*8)/2-60,190,"Sponsors:".Length*8+10,20),"Sponsors:")){sponsors();}
		//if(GUI.Button(new Rect((int)(Screen.width-"Contact:".Length*8)/2-60,190,"Contact:".Length*8+10,20),"Contact:")){//1Application.ExternalCall("replace",host+"/site/contact");
		//}
		
		if(GUI.Button(new Rect(10,Screen.height-150,70,20),"ok")){ 
			screenend();
		}
		
		GUI.EndGroup();
	}
	public void loadgame(){
		screennew();
		showloadgame=true;
		GUI.BeginGroup(new Rect(60,60, Screen.width-120,Screen.height-120));
		GUI.Box(new Rect(0,0, Screen.width-120,Screen.height-120),"");
		portals= GameObject.FindGameObjectWithTag("init").GetComponent<init>().portals;
		int pos=10;
		int portalchilds=portals.transform.GetChildCount();
		scrollViewVector = GUI.BeginScrollView (new Rect (10,10,Screen.width-140,Screen.height-170), scrollViewVector, new Rect (0, 0, 400, portalchilds*30+10));
		for (int i=0;i<portalchilds;i++){
			portal port=portals.transform.GetChild(i).transform.GetChild(0).GetComponent<portal>();
			if(port.isok){
			if(GUI.Button(new Rect(10,pos,(port.game+" "+"minlevel"+" "+port.minLevel.ToString()).Length*8+10,20),port.game+" "+"minlevel"+" "+port.minLevel.ToString())){
					player.transform.position=port.transform.parent.position;
				screenend();
				}
			pos+=30;
			}
			
		}
		if(portalchilds==0){
			if(GUI.Button(new Rect(10,10,"Start".Length*8+10,20),"Start"))GameObject.FindGameObjectWithTag("init").GetComponent<init>().start();
			if(GUI.Button(new Rect(10,40,"Story".Length*8+10,20),"Story"))GameObject.FindGameObjectWithTag("init").GetComponent<init>().classic();
				
			}
		GUI.EndScrollView();
		if(GUI.Button(new Rect(10,Screen.height-150,70,20),"ok")){ 
			screenend();
		}
		
		GUI.EndGroup();
	}
	public void chageLanguage(){
		screennew();
		showchangeLanguage=true;
		GUI.BeginGroup(new Rect(60,60, Screen.width-120,Screen.height-120));
		GUI.Box(new Rect(0,0, Screen.width-120,Screen.height-120),"");
		scrollViewVector = GUI.BeginScrollView (new Rect (10,10,Screen.width-140,Screen.height-170), scrollViewVector, new Rect (0, 0, 400, 300));
			if(GUI.Button(new Rect(10,10,100,20), "English")){StartCoroutine(i18n.getlanguage("language/en"));}
			if(GUI.Button(new Rect(10,30,100,20),"Magyar")){StartCoroutine(i18n.getlanguage());}
			
		GUI.EndScrollView();
		if(GUI.Button(new Rect(10,Screen.height-150,70,20),"ok")){ 
			screenend();
		}
		
		GUI.EndGroup();
	
	}
	
	public void Option(){
		screennew();
		showOption=true;
		GUI.BeginGroup(new Rect(60,60, Screen.width-120,Screen.height-120));
		GUI.Box(new Rect(0,0, Screen.width-120,Screen.height-120),"");
		GUI.Box(new Rect(10,10,100,30),"music:");
		player.transform.GetChild(5).audio.volume=GUI.HorizontalSlider(new Rect(110,10,100,30),player.transform.GetChild(5).audio.volume,0.0f,.3f);
		GUI.Box(new Rect(10,50,100,30),"effect:");
		player.audio.volume=GUI.HorizontalSlider(new Rect(110,50,100,30),player.audio.volume,0.0f,.3f);
		GUI.Box(new Rect(10,90,100,30),"Mouse sens:");
		player.GetComponent<MouseLook>().sensitivityX=GUI.HorizontalSlider(new Rect(110,90,100,30),player.GetComponent<MouseLook>().sensitivityX,0.0f,20f);
		
		if(GUI.Button(new Rect(10,Screen.height-150,70,20),"ok")){ 
		screenend();
		}
		
		GUI.EndGroup();
	
	}
	public IEnumerator startScreen(){
		screennew(false);
		showStart=true;
		yield return new WaitForSeconds(3f);
		screenend();
	}
	public void start(){
		GUI.BeginGroup(new Rect(60,60, Screen.width-120,Screen.height-120));
		GUI.Box(new Rect(0,0, Screen.width-120,Screen.height-120),"");
		GUI.Label(new Rect(10,10,100,30),"score:");
		GUI.Label(new Rect(110,10,100,30),player.score.ToString());
		GUI.Label(new Rect(210,10,100,30),"hiscore:");
		GUI.Label(new Rect(310,10,100,30),player.hiscore.ToString());
		GUI.Label(new Rect(410,10,100,30),"life:");
		GUI.Label(new Rect(510,10,100,30),player.life.ToString());
		GUI.Label(new Rect((Screen.width-120)/2-"level:".Length*8+10,(Screen.height-120)/2,100,30),"level:");
		GUI.Label(new Rect((Screen.width-120)/2-"level:".Length*8+110,(Screen.height-120)/2,100,30),(prop.startlevel).ToString()+(prop.endlevel>1?"-"+(prop.endlevel-1):"").ToString());
		
		GUI.EndGroup();
	
	}
	public void endd(){
		StartCoroutine(endScreen());
	}
	public IEnumerator endScreen(){
		screennew(false);
		showend=true;
		player.playmusic(-1);
		player.audio.PlayOneShot(player.gameover);
		yield return new WaitForSeconds(6f);
		screenend();
		player.playmusic(-1);
		player.playmusic(0);
		
	}
	
	public GUIStyle style;
	public void end(){
		GUI.BeginGroup(new Rect(60,60, Screen.width-120,Screen.height-120));
		GUI.Box(new Rect(0,0, Screen.width-120,Screen.height-120),"");
		style=new GUIStyle();
		style.fontSize=30;
		style.normal.textColor=Color.white;
		GUI.Box(new Rect((Screen.width-120-("GAME OVER:(".Length*20+10))/2,(Screen.height-180)/2,"GAME OVER:(".Length*20+10,30), "GAME OVER:(",style);
		
		GUI.EndGroup();
	
	}
	
}
