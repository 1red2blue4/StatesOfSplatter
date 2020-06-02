using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterphysics : MonoBehaviour {
	private int delay=10;
	private float attraction=.15f;
	private float repulsion=100f;
	private Rigidbody myBody;
	public GameObject ice;
	public GameObject gas;
	private bool temp=true;
	// Use this for initialization
	void Start () {
		myBody=transform.GetComponent<Rigidbody>();
	}

	void Update(){
		if(float.IsNaN(transform.position.x) || float.IsNaN(transform.position.y) || float.IsNaN(transform.position.z)){
			transform.position=new Vector3(-1000,-1000,-1000);
		}

		if(transform.GetComponent<Temperature>().temperature>=120){
			Evaporate();
		}
		if(transform.GetComponent<Temperature>().temperature<=-20){
			freeze();
		}



		if(delay>0){
			delay--;
			if(float.IsNaN(myBody.velocity.x) || float.IsNaN(myBody.velocity.y) || float.IsNaN(myBody.velocity.z)){
				myBody.velocity=new Vector3(0,0,0);
			}
			return;
		}
		else{
			transform.GetComponent<SphereCollider>().enabled=true;
			RaycastHit hit;
			Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3f*Mathf.PI);
			int i = 0;
			Vector3 attractionForce=new Vector3(0,0,0);
			Vector3 repulsionForce=new Vector3(0,0,0);
			while (i < hitColliders.Length) {
				float distance=Vector3.Distance(transform.position,hitColliders[i].transform.position);

				if(hitColliders[i].tag=="Water" ){

					if(distance>Mathf.PI*2/3 && distance<Mathf.PI*4/3){
						
					}
					else if(distance>Mathf.PI){

						float force=Mathf.Cos(distance)+1;
						force*=attraction;
						attractionForce+=(hitColliders[i].transform.position-transform.position)*force;


					}
					else if(distance>Mathf.PI/2 && distance<Mathf.PI){
						float force=Mathf.Cos(distance)+1;
						force*=repulsion;
						repulsionForce+=(transform.position-hitColliders[i].transform.position)*force;


					}
				}
				i++;
			}
			if(float.IsNaN(myBody.velocity.x) || float.IsNaN(myBody.velocity.y) || float.IsNaN(myBody.velocity.z)){
				myBody.velocity=new Vector3(0,0,0);
			}
			if(attractionForce.magnitude>0 && !(float.IsNaN(attractionForce.x) || float.IsNaN(attractionForce.y) || float.IsNaN(attractionForce.z)))
			myBody.velocity+=attractionForce*Time.deltaTime;
			if(repulsionForce.magnitude>0 && !(float.IsNaN(repulsionForce.x) || float.IsNaN(repulsionForce.y) || float.IsNaN(repulsionForce.z)))
			myBody.velocity+=repulsionForce*Time.deltaTime;
			
			
		}


	}




	void freeze(){
			Instantiate(ice,transform.position,transform.rotation,null);
			Destroy(transform.gameObject);
		}

	void Evaporate(){
		Instantiate(gas,transform.position,transform.rotation,null);
		Destroy(transform.gameObject);
	}









}