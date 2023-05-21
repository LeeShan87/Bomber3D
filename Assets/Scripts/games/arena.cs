using UnityEngine;
using System.Collections;

public class arena : gameBehavior
{
	// Use this for initialization
	public GameObject playerObj;
	public player player;
	
	void Start ()
	{	this.name="arena";
		this.playerObj=GameObject.FindGameObjectWithTag("Player");
		this.player=playerObj.GetComponent<player>();
		this.player.hiscore=player.playerData["hiscore_arena"];
	 	
		GameObject.FindGameObjectWithTag("init").GetComponent<init>().reset();
		 // Application.LoadLevel("game");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!loaded)if(!Application.isLoadingLevel){this.loaded=true; newGame();}
		if(loaded)isGameEnd();
		if(!IsInvoking("Game"))Invoke("Game",15f);
		if(timer<0){if(!GameObject.FindGameObjectWithTag("portal"))AddPortal(new Vector3(1f,1f,1f));GameObject.FindGameObjectWithTag("portal").GetComponent<portal>().chColor("ok");}
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
				//resetLevel();
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
		//if(player.timer<0){death();return true;}
	  if(player.life<0){	player.transform.position=new Vector3(28f,1.1f,15f);
		player.GetComponent<gui>().endd();
		//player.audio.PlayOneShot(player.gameover);
			Application.LoadLevel("start");
		Destroy(this);return true;}
		return false;
	}
	public override void Game ()
	{
		if(player.hiscore>player.playerData["hiscore_arena"]) StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<data>().savePlayerData("hiscore_arena",player.hiscore));
		//AddAdd(new Vector3((Random.Range(0,(int)(this.x)/2))*2+1.5f,1f,(Random.Range(0,(int)(this.z)/2))*2+1.5f),Random.Range(0,this.adds.Length));
		AddEnemy(new Vector3((Random.Range(0,(int)(this.x)/2))*2+1,1f,(Random.Range(0,(int)(this.z)/2))*2+1));
		
	}
}

