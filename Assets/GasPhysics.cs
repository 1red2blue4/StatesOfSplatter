using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPhysics : MonoBehaviour {
	public bool formed=false;
	public bool parent;
	private GameObject target=null;
	public GameObject water;
	public float speed;
	private int counter;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update(){
		if(transform.GetComponent<Temperature>().temperature<=100){
			condense();
		}
		if(formed){
			if(counter>0)counter--;
			if(parent){
				Transform target=transform;
				foreach(Transform child in transform){
					if(child.transform.position.y>target.position.y){
						target=child;
					}
				}

				transform.GetComponent<Rigidbody>().velocity=new Vector3((target.position.x-transform.position.x)*2,15,0);
			}
			else{
				if(Vector3.Distance(transform.position,transform.parent.position)>10){
					transform.GetComponent<Rigidbody>().velocity=transform.parent.position-transform.position;
					if(transform.GetComponent<Rigidbody>().velocity.magnitude!=0)
						transform.GetComponent<Rigidbody>().velocity/=transform.GetComponent<Rigidbody>().velocity.magnitude;
					transform.GetComponent<Rigidbody>().velocity*=speed;
				}
				if(counter==0){
					counter=15;
					transform.GetComponent<Rigidbody>().velocity=new Vector3(Random.Range(-1,2),Random.Range(-1,2),Random.Range(-1,2));
					if(transform.GetComponent<Rigidbody>().velocity.magnitude!=0)
						transform.GetComponent<Rigidbody>().velocity/=transform.GetComponent<Rigidbody>().velocity.magnitude;
					transform.GetComponent<Rigidbody>().velocity*=speed;
				}
			}


			return;
		}
		RaycastHit hit;
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 12f*Mathf.PI);
		int i = 0;
		while (i < hitColliders.Length) {
			float distance=Vector3.Distance(transform.position,hitColliders[i].transform.position);

			if(hitColliders[i].tag=="Gas" && hitColliders[i].transform!=transform && hitColliders[i].GetComponent<GasPhysics>().parent){
				
				transform.parent=hitColliders[i].transform;

			}
			i++;
		}
		if(transform.parent==null){
			parent=true;
			transform.GetComponent<SphereCollider>().radius=2;
		}
		formed=true;
	}



	public void condense(){
		if(transform.childCount>0){
			transform.GetComponent<Temperature>().temperature+=.1f;

			GameObject temp=(GameObject)Instantiate(water,transform.GetChild(0).position,transform.rotation,null);
			temp.transform.localScale=new Vector3(4,4,4);
			temp.transform.GetComponent<Rigidbody>().velocity=new Vector3(0,0,0);
			
			Destroy(transform.GetChild(0).gameObject);
		
		}
		else{
			GameObject temp=(GameObject)Instantiate(water,transform.position,transform.rotation,null);
			temp.transform.localScale=new Vector3(4,4,4);
			temp.transform.GetComponent<Rigidbody>().velocity=new Vector3(0,0,0);

			Destroy(transform.gameObject);
		}
	}
}








/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPhysics : MonoBehaviour {
	public GameObject target1;
	public float speed;
	private int counter;
	public GameObject ice;
	public GameObject water;
	// Use this for initialization
	void Start () {
		target1=null;
		RaycastHit hit;
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10f*Mathf.PI);
		int i = 0;
		while (i < hitColliders.Length) {
			float distance=Vector3.Distance(transform.position,hitColliders[i].transform.position);

			if(hitColliders[i].tag=="GasMaster" && hitColliders[i].transform!=transform){
				if(target1==null){
					target1=hitColliders[i].transform.gameObject;
				}
			}
			i++;
		}
		if(target1==null){transform.tag="GasMaster";}
		transform.GetComponent<Rigidbody>().velocity=new Vector3(0,speed,0);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.GetComponent<Temperature>().temperature<=100){
			Condensate();
		}


		if(counter==15&&target1&&Vector3.Distance(target1.transform.position,transform.position)>10){
			transform.GetComponent<Rigidbody>().velocity=target1.transform.position-transform.position;
			if(transform.GetComponent<Rigidbody>().velocity.magnitude!=0)
			transform.GetComponent<Rigidbody>().velocity/=transform.GetComponent<Rigidbody>().velocity.magnitude;
			transform.GetComponent<Rigidbody>().velocity*=speed;
			counter=0;
		}

		else if(counter==15 && tag!="GasMaster"){
			counter=0;
			transform.GetComponent<Rigidbody>().velocity=new Vector3(Random.Range(-1,2),Random.Range(-1,2),Random.Range(-1,2));
			if(transform.GetComponent<Rigidbody>().velocity.magnitude!=0)
			transform.GetComponent<Rigidbody>().velocity/=transform.GetComponent<Rigidbody>().velocity.magnitude;
			transform.GetComponent<Rigidbody>().velocity*=speed;
		}
		counter++;
		if(tag=="GasMaster" || target1==null){
			counter=0;
			target1=null;
			RaycastHit hit;
			Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10f*Mathf.PI);
			int i = 0;
			while (i < hitColliders.Length) {
				float distance=Vector3.Distance(transform.position,hitColliders[i].transform.position);

				if(hitColliders[i].tag=="GasMaster" && hitColliders[i].transform!=transform){
					if(target1==null){
						target1=hitColliders[i].transform.gameObject;
						transform.tag="Gas";
					}
				}
				i++;
			}
			if(target1==null){transform.tag="GasMaster";}
			transform.GetComponent<Rigidbody>().velocity=new Vector3(0,speed,0);
		}
		else{
			if(target1&&target1.GetComponent<GasPhysics>().target1){
				target1=target1.GetComponent<GasPhysics>().target1;
			}
		}
	}

	void Condensate(){
		GameObject temp=Instantiate(water,transform.position,transform.rotation,null);
		temp.transform.localScale=new Vector3(4,4,4);
		Destroy(transform.gameObject);
	}


}
*/