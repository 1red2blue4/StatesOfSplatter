using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
	public float target;
	private float counter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(counter>=target){
			transform.GetChild(0).gameObject.SetActive(true);
			transform.GetChild(2).gameObject.SetActive(true);
		}
		float temp=(counter/target)*1.9f;
		temp-=1.65f;
		if(temp>.25f)temp=.25f;
		transform.GetChild(1).localPosition=new Vector3(0,temp,0);
	}

	void OnCollisionEnter(Collision other){
		if(other.transform.tag=="Water"){
			Destroy(other.transform.gameObject);
			counter++;
		}
	}
}
