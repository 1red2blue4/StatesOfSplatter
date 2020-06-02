using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperature : MonoBehaviour {
	public float temperature;
	private float decay;
	// Use this for initialization
	void Start () {
		decay=0;//decay=0.05f;
	}
	
	// Update is called once per frame
	void Update () {
		if(temperature<-40){
			temperature=-40;
		}
		if(temperature>140){
			temperature=140;
		}

		if(temperature>100)temperature-=decay;
		if(temperature<0)temperature+=decay;
	}
}
