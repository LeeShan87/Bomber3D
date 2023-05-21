using UnityEngine;
using System.Collections;

public class prop : MonoBehaviour {
	public int maxLevel;
	public int level;
	public int startlevel;
	public int endlevel;
	public int minlevel;
	public int score;
	public int hiscore;
	public string game;
	public int x;
	public int z;
	public string adds;
	public int val;
	// Use this for initialization
	void Awake(){
		DontDestroyOnLoad(this.gameObject);
	}
	void Start () {
		this.level=0;
		this.maxLevel=8;
		this.x=31;
		this.z=17;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void addGame(string game){
		this.game=game;
		switch(game){
		case "arena":{this.gameObject.AddComponent<arena>();break;}
		case "tillTheEnd":{this.gameObject.AddComponent<tillTheEnd>();break;}	
		case "story":{this.gameObject.AddComponent<story>();break;}
			case "classicgame":{this.gameObject.AddComponent<classicgame>();break;}
		}
		
	}
	public gameBehavior getGame(){
		switch(this.game){
		case "arena":{return this.GetComponent<arena>();break;}
			case "story":{return this.GetComponent<story>();break;}
			case "tillTheEnd":{return this.GetComponent<tillTheEnd>();break;}
			case "classicgame":{return this.GetComponent<classicgame>();break;}
		}
		return null;
	}
}
