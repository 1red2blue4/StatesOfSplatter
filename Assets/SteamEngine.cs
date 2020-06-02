using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamEngine : MonoBehaviour {
	public GameObject actuate;
	public bool actuateTrue;
	private int counter;
	private bool condense;
	public int target;
	private int animateCounter;
	private bool animate;
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	// Use this for initialization
	void Start () {
		counter=0;
		animate=false;
		animateCounter=0;
	}

	// Update is called once per frame
	void Update () {
		if(animate){
			transform.GetChild(3).gameObject.SetActive(true);
			animateCounter++;
			if((animateCounter/10)%3==0){
				transform.GetChild(2).GetComponent<SpriteRenderer>().sprite=sprite1;
			}
			if((animateCounter/10)%3==1){
				transform.GetChild(2).GetComponent<SpriteRenderer>().sprite=sprite2;
			}
			if((animateCounter/10)%3==2){
				transform.GetChild(2).GetComponent<SpriteRenderer>().sprite=sprite3;
			}

		}
		condense=true;
		if(counter>=target){
			actuate.SetActive(actuateTrue);
			counter=target;
			animate=true;
		}
		else{
			actuate.SetActive(!actuateTrue);
		}
		transform.GetChild(0).localScale=new Vector3(((float)counter/(float)target)*0.09875f,0.01299996f,30);
	}

	void OnTriggerStay(Collider other){

		if(other.transform.tag=="Gas" && condense){
			condense=false;
			if(counter<target)
			counter+=1;
			
			other.transform.GetComponent<GasPhysics>().condense();
		}
	}
}