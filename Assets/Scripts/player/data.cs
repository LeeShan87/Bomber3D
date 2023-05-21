using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class data : MonoBehaviour
{	
	public player player;
	public string showerror="";
	public bool started;
	public System.DateTime time; 
	public string host;
	public Dictionary<string,int> playerData;
	public Dictionary<string,int> playerDonate;
	
	
	void Awake(){
		player=GetComponent<player>();
		player.playerData=new  Dictionary<string, int>();
		
		StartCoroutine(getPlayerData());
	}
	public IEnumerator getPlayerData(){
		
		player.started=false;
		if(!player.playerData.ContainsKey("level")){
		player.playerData.Add("level",1);
			//player.playerData.Add("level",1);
		player.playerData.Add("bombs",2);
		player.playerData.Add("range",2);
		player.playerData.Add("speed",9);
		player.playerData.Add("trigger",0);
		player.playerData.Add("wallthrough",0);
		player.playerData.Add("bombthrough",0);
		player.playerData.Add("bombprof",0);
		player.playerData.Add("life",3);
		
				player.started= true;
		}
		yield return new WaitForSeconds(0);
	}

	public IEnumerator savePlayerData(string attrib="", int val=0){
		//Debug.Log(attrib+" val:"+val);
		if(attrib!=""){
			if(attrib!="level"&&attrib!="hiscore_arena"
				&&attrib!="hiscore_tilltheend"&&attrib!="hiscore_story"&&attrib!="hiscore_classic")val+=
				player.playerData[attrib]; 
		}
		yield return new WaitForSeconds(0);
		
	}
	void OnGUI(){
		if(showerror!="")
			GUI.Box(new Rect((Screen.width-(showerror.Length*8+10))/2,Screen.height/2,(showerror.Length*8+10),30),showerror);
	}
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

