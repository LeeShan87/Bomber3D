using UnityEngine;
using System.Collections;

abstract public class GameObjBehavior : MonoBehaviour {
	public int id;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	abstract public void Bombed();
	
	void OnParticleCollision(GameObject other) {
        //Debug.Log("exp");
		
    }
	
	void OnTriggerEnter(Collider other) {
		//Debug.Log(other.tag);
		//Debug.Log("exp");
	}
	public IEnumerator waitsecs(int i){
		yield return new WaitForSeconds((float)i);
	}
}
