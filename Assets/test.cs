using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	public int shift=6;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
void OnGUI() {
        if(GUI.RepeatButton(new Rect(Screen.width*0.8f,Screen.height*.4f,Screen.width*.1f,Screen.height*.2f),"gáz")){
			transform.position=new Vector3(transform.position.x+ Time.deltaTime*shift,transform.position.y,transform.position.z);
			
		}
		if (GUI.Button(new Rect(Screen.width*.8f,Screen.height*.7f,Screen.width*.2f,Screen.width*.1f),"shift "+shift/6)){
			shift+=6;
		}
    }
	
}
