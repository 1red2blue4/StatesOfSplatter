using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWheel : MonoBehaviour {
	public GameObject actuate;
	public bool actuateTrue;
	private Quaternion prevRot;
	public float counter;
	public float target;
	// Use this for initialization
	void Start () {
		prevRot=transform.rotation;
		counter=0;
	}
	
	// Update is called once per frame
	void Update () {
		if(prevRot!=transform.rotation){
			counter+= (Mathf.Abs(prevRot.y-transform.rotation.y));
		}
		if(counter>target){
			if(actuate)
			actuate.SetActive(actuateTrue);
		}
		else{	
			if(actuate)
			actuate.SetActive(!actuateTrue);
		}
		prevRot=transform.rotation;
	}
}
