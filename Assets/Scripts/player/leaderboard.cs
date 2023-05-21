using UnityEngine;
using System.Collections;

public class leaderboard : MonoBehaviour
{
	public string host;
	public string[] scores;
	public bool loaded;
	// Use this for initialization
	void Start ()
	{
	host=GetComponent<data>().host;
	StartCoroutine( getdata());
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	public IEnumerator getdata(string order=""){
		loaded=false;
		WWW www=new WWW(host+"/game/leaderboard/"+order);
		yield return www;
		string data=www.text;
		if(data.StartsWith("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">"))GetComponent<data>().showerror="No logged in user";
			else{
		scores=data.Split('&');
		}//yield return new WaitForSeconds(1);
		loaded=true;
	}
}

