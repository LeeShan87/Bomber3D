using UnityEngine;
using System.Collections;

public class playmusic : MonoBehaviour {
		public AudioClip[] music;
		public AudioClip[] effect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void play(int i){
		if(i<0)audio.mute=!audio.mute;
		else{
		audio.clip=music[i];
		audio.loop=true;
		audio.Play();
		}
	}
	public void playone(int i){
		audio.PlayOneShot(effect[i]);
	}
}
