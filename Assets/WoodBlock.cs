using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBlock : MonoBehaviour {
	public float BreakingPoint;
	private float Weight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Weight>BreakingPoint){
			transform.GetChild(0).gameObject.SetActive(false);
			transform.GetComponent<BoxCollider>().enabled=false;
			transform.GetChild(1).gameObject.SetActive(true);
			foreach(Transform child in transform.GetChild(1)){
				child.GetComponent<Rigidbody>().velocity=new Vector3(Random.Range(-100,100),Random.Range(-70,30),0);
			}
		}
		Weight=0;
	}

	/*void OnCollisionEnter(Collision other){
		if(other.transform.tag=="Ice"){
			Weight+=other.transform.GetComponent<icePhysics>().scale*other.transform.GetComponent<Rigidbody>().velocity.magnitude;
		}
	}*/

	void OnCollisionStay(Collision other){
		if(other.transform.tag=="Ice"){
			Weight+=other.transform.GetComponent<icePhysics>().scale;
		}
	}


}
