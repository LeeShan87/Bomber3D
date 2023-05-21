using UnityEngine;
using System.Collections;

public class endScene : MonoBehaviour {
	public prop prop;
	// Use this for initialization
	void Start () {
		prop=GameObject.FindGameObjectWithTag("prop").GetComponent<prop>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if(GUI.Button(new Rect(10,10,200,200),"Nyertél! kezded előről?")){
			Destroy(GameObject.FindGameObjectWithTag("prop"));
			Application.LoadLevel("start");
		}
		GUI.Label(new Rect(200,10,250,20),"score:");
		GUI.Label(new Rect(260,10,300,20),prop.score.ToString());
		GUI.Label(new Rect(200,30,250,40),"hiscore:");
		GUI.Label(new Rect(260,30,300,40),prop.hiscore.ToString());
	}
}
