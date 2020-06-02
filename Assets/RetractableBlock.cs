using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractableBlock : MonoBehaviour {
	public Sprite inSprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.GetChild(0).gameObject.activeSelf){
			transform.GetComponent<BoxCollider>().enabled=false;
			foreach(Transform child in transform){
				if(child.GetComponent<SpriteRenderer>()){
					child.GetComponent<SpriteRenderer>().sprite=inSprite;
					child.localPosition=new Vector3(child.localPosition.x,child.localPosition.y,.15f);
				}
			}
		}
	}
}
