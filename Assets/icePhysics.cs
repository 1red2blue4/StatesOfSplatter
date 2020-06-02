using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icePhysics : MonoBehaviour {
	public float scale;
	private bool formed=false;
	private GameObject target=null;
	public GameObject water;
	public GameObject gas;
	// Use this for initialization
	void Start () {
		scale=2;
	}
	
	// Update is called once per frame
	void Update(){
		if(transform.GetComponent<Temperature>().temperature>=0){
			melt();
		}


		transform.GetComponent<Rigidbody>().mass=scale*scale;
		if(transform.localScale.x<Mathf.Pow(scale,1/2f)){
			transform.localScale+=new Vector3(0.1f,0.1f,0.1f);
		}
		else if(transform.localScale.x-1>Mathf.Pow(scale,1/2f)){
			transform.localScale-=new Vector3(0.1f,0.1f,0.1f);
		}
		//print(target);
		if(target!=null){
			if(target.GetComponent<icePhysics>().target!=null){
				target=target.GetComponent<icePhysics>().target;
			}
			transform.position=Vector3.Lerp(transform.position,target.transform.position,0.2f);
			if(Vector3.Distance(transform.position,target.transform.position)<3){
				Destroy(transform.gameObject);
			}
		}
		else{
			if(transform.GetComponent<BoxCollider>().enabled==false){
				Destroy(transform.gameObject);
			}
		}
		if(formed){
			return;
		}
		RaycastHit hit;
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 8f*Mathf.PI);
		int i = 0;
		while (i < hitColliders.Length) {
			float distance=Vector3.Distance(transform.position,hitColliders[i].transform.position);

			if(hitColliders[i].tag=="Ice" && hitColliders[i].transform!=transform && hitColliders[i].GetComponent<icePhysics>().scale<100){
				if(hitColliders[i].GetComponent<icePhysics>().scale<2)hitColliders[i].GetComponent<icePhysics>().scale=2;
				hitColliders[i].GetComponent<icePhysics>().scale+=scale;
				target=hitColliders[i].transform.gameObject;
				transform.tag="Untagged";
				transform.GetComponent<BoxCollider>().enabled=false;
				transform.GetComponent<Rigidbody>().useGravity=false;

				i=1000;

			}
			i++;
		}
		formed=true;
	}



	void melt(){
		transform.GetComponent<Temperature>().temperature-=.1f;
			Vector3 randomVariance=new Vector3(Random.Range(-3.0f,3.0f),Random.Range(-3.0f,3.0f),Random.Range(-3.0f,3.0f));
			GameObject temp=(GameObject)Instantiate(water,transform.position+randomVariance,transform.rotation,null);
			temp.transform.localScale=new Vector3(4,4,4);
			temp.transform.GetComponent<Rigidbody>().velocity=new Vector3(0,0,0);
			scale-=2;
			transform.localScale-=new Vector3(0.3f,0.3f,0.3f);
			if(scale<2){
				Destroy(transform.gameObject);

			}

	}
}
