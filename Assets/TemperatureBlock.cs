using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureBlock : MonoBehaviour {
	public bool cold;
	public float temperature;
	private int heatTransfer;
	// Use this for initialization
	void Start () {
		heatTransfer=1;
	}
	
	// Update is called once per frame
	void Update () {
		if(temperature<=0){
			Destroy(transform.gameObject);
		}
		if(cold){
			transform.GetComponent<MeshRenderer>().material.color=new Color(0,0,1,temperature/25000);
		}
		else{
			transform.GetComponent<MeshRenderer>().material.color=new Color(1,0,0,temperature/25000);
		}
	}

	void OnTriggerStay(Collider other){
		if(other.transform.GetComponent<Temperature>()){
			if(cold){
				other.transform.GetComponent<Temperature>().temperature-=heatTransfer;
			}
			else{
				other.transform.GetComponent<Temperature>().temperature+=heatTransfer;
			}
			temperature-=heatTransfer;
		}
	}
}
