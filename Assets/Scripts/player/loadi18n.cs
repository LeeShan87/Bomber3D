using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class loadi18n : MonoBehaviour
{
	public string host;
	public bool loaded;
	public Dictionary<string,string> i18n;
	// Use this for initialization
	IEnumerator Start ()
	{
		Debug.Log("i18n start");
		host=GetComponent<data>().host;
		yield return StartCoroutine( getlanguage("language/en"));
		Debug.Log("i18n end");
		
	}
	public IEnumerator getlanguage(string language=""){
		loaded=false;
		WWW www=new WWW(host+"/game/getlanguage/"+language);
		yield return www;
		string data=www.text;
		if(data.StartsWith("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">"))GetComponent<data>().showerror="No logged in user";
			else{
		Debug.Log("language data:"+data);
		string[] splitdata=data.Split('*');
		//OnGUI
		i18n=new Dictionary<string, string>();
		i18n.Add("info",splitdata[27]);		
		i18n.Add("fullsrceen",splitdata[28]);		
		i18n.Add("bombs",splitdata[0]);		
		i18n.Add("time",splitdata[1]);		
		i18n.Add("point",splitdata[2]);		
		i18n.Add("hiscore",splitdata[3]);		
		i18n.Add("life",splitdata[4]);		
		i18n.Add("enemys",splitdata[5]);		
		i18n.Add("ok",splitdata[6]);
		i18n.Add("exit",splitdata[7]);
		Debug.Log ("loaded Gui");
		//info()
		i18n.Add("controls",splitdata[8]);		
		i18n.Add("addbombs",splitdata[9]);
		i18n.Add("explode",splitdata[10]);
		i18n.Add("mapmode",splitdata[11]);
		i18n.Add("adds",splitdata[12]);
		i18n.Add("addbomb",splitdata[13]);
		i18n.Add("addrange",splitdata[14]);
		i18n.Add("addlife",splitdata[15]);
		i18n.Add("addspeed",splitdata[16]);
		i18n.Add("addtrigger",splitdata[17]);
		i18n.Add("addwallthrough",splitdata[18]);
		i18n.Add("addbombthrough",splitdata[19]);
		i18n.Add("addbombprof",splitdata[20]);
		Debug.Log ("loaded info");
		//portalscreen
		i18n.Add("minlevel",splitdata[21]);
		i18n.Add("bonus",splitdata[22]);
		//portal descriptions
		i18n.Add("desc_arena",splitdata[23]);
		i18n.Add("desc_story",splitdata[24]);
		i18n.Add("desc_classic",splitdata[25]);
		i18n.Add("desc_tilltheend",splitdata[26]);
		Debug.Log ("loaded desc");
		//
		i18n.Add("stillenemy",splitdata[29]);		
		i18n.Add("desc_storygame",splitdata[30]);		
		i18n.Add("loadgame",splitdata[31]);		
		i18n.Add("changelang",splitdata[32]);		
		Debug.Log ("loaded");
		loaded=true;
		}
	}
	// Update is called once per frame
	void Update ()
	{
	
	}
}

