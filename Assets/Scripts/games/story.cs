using UnityEngine;
using System.Collections;

public class story : gameBehavior
{
	// Use this for initialization
	public GameObject playerObj;
	public player player;
	public bool winRuning=false;
	void Start ()
	{	this.name="story";
		this.playerObj=GameObject.FindGameObjectWithTag("Player");
		this.player=playerObj.GetComponent<player>();
		this.player.hiscore=player.playerData["hiscore_story"];
	 	GameObject.FindGameObjectWithTag("init").GetComponent<init>().reset();
		 //Application.LoadLevel("game");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!loaded)if(!Application.isLoadingLevel){this.loaded=true; newGame();}
		if(loaded)isGameEnd();
		//if(!IsInvoking("Game"))Invoke("Game",15f);
		//if(timer<0){if(!GameObject.FindGameObjectWithTag("portal"))AddPortal(new Vector3(1.5f,1f,1.5f));GameObject.FindGameObjectWithTag("portal").GetComponent<portal>().chColor("ok");}
	}
	public override IEnumerator death ()
	{
		if(!this.isdeath){
		player.audio.PlayOneShot(player.deathsound);
		
		if(playerObj.transform.position!=player.startPos){
		player.life--;
		player.score=0;
		player.initAdds();
		playerObj.transform.position=player.startPos;
		resetLevel();
			//init.initobj();
		}
			this.isdeath=true;
		yield return new WaitForSeconds(.01f);
			player.GetComponent<CharacterMotor>().movement.velocity=Vector3.zero;
		yield return new WaitForSeconds(3f);
		this.isdeath=false;
		}
	}
	public override bool isGameEnd ()
	{
		if(timer<0){StartCoroutine(death());return true;}
	  if(player.life<0){	player.transform.position=new Vector3(35f,1.1f,35f);
		player.GetComponent<gui>().endd();
		//player.audio.PlayOneShot(player.gameover);
			GameObject.FindGameObjectWithTag("init").GetComponent<init>().classic();
		Destroy(this);;return true;}
		if(!Application.isLoadingLevel)
			if(this.addok.transform.GetChildCount()==0&&this.enemyk.transform.GetChildCount()==0&&this.portals.transform.GetChildCount()==0){
			if(!winRuning)StartCoroutine(win());
			return true;
		}
		return false;
		
	}
	public IEnumerator win(){
		winRuning=true;
			player.transform.position=new Vector3(35f,1.1f,35f);
			
		if(player.playerData["level"]==prop.minlevel){	
		yield return StartCoroutine( GameObject.FindGameObjectWithTag("Player").GetComponent<data>().savePlayerData("level",prop.minlevel+1));
		yield return StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<data>().savePlayerData(prop.adds,prop.val));
		if(player.hiscore>player.playerData["hiscore_story"]) yield return StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<data>().savePlayerData("hiscore_story",player.hiscore));
		}
		
		GameObject.FindGameObjectWithTag("init").GetComponent<init>().classic();
		winRuning=false;	
		Destroy(this);
	}
	public override void Game ()
	{if(player.hiscore>player.playerData["hiscore_story"]) StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<data>().savePlayerData("hiscore_story",player.hiscore));
		player.initAdds();
		if(prop.level+1==prop.maxLevel){if(player.playerData["level"]==prop.minlevel)AddAdd(teglak.transform.GetChild(Random.Range(0,teglak.transform.GetChildCount())).position,prop.adds);}
		else {AddPortal(teglak.transform.GetChild(Random.Range(0,teglak.transform.GetChildCount())).position);}
	}
	
}

