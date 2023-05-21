using UnityEngine;
using System.Collections;

public class tillTheEnd : gameBehavior
{
	public GameObject playerObj;
	public player player;
	
	
	// Use this for initialization
	void Start ()
	{this.name="tillTheEnd";
		this.playerObj=GameObject.FindGameObjectWithTag("Player");
		this.player=playerObj.GetComponent<player>();
		this.player.hiscore=player.playerData["hiscore_tilltheend"];
	 	//this.diff=(prop.level>this.enemy.Length?this.enemy.Length:prop.level);
		GameObject.FindGameObjectWithTag("init").GetComponent<init>().reset();
		 //Application.LoadLevel("game");
		
		//Invoke("constr",2f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!loaded)if(!Application.isLoadingLevel){this.loaded=true; newGame();}
	if(loaded)isGameEnd();
	}
	public override bool isGameEnd ()
	{
		if(timer<0){StartCoroutine(death());return true;}
	  if(player.life<0){	player.transform.position=new Vector3(28f,1.1f,15f);
		player.GetComponent<gui>().endd();
		//player.audio.PlayOneShot(player.gameover);
			Application.LoadLevel("start");
		Destroy(this);return true;}
		return false;
	}
	public override IEnumerator death ()
	{
		if(!this.isdeath){
		player.audio.PlayOneShot(player.deathsound);
		
		if(playerObj.transform.position!=player.startPos){
		player.life--;
		player.score=0;
		//player.initAdds();
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
	public override void Game ()
	{
		if(player.hiscore>player.playerData["hiscore_tilltheend"]) StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<data>().savePlayerData("hiscore_tilltheend",player.hiscore));
		//if(!GameObject.FindGameObjectWithTag("add")) 
		//	AddAdd(teglak.transform.GetChild(Random.Range(0,teglak.transform.GetChildCount())).position);
		//if(!GameObject.FindGameObjectWithTag("portal")) 
		{AddPortal(teglak.transform.GetChild(Random.Range(0,teglak.transform.GetChildCount())).position);Debug.Log("postal oinit");}
		Debug.Log("game");
	}
}

