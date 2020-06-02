using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanAir : MonoBehaviour {
	public Vector3 Force;
	public Sprite fanOn;
	// Use this for initialization
	void Start () {
		transform.parent.GetChild(1).GetComponent<SpriteRenderer>().sprite=fanOn;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other){
		
		if(other.transform.tag=="Gas"){
			
			other.transform.position+=Force;
		}
		if(other.transform.tag=="Water"){

			other.transform.position+=Force/5;
		}
	}
}
