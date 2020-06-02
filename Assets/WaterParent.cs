using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParent : MonoBehaviour {
	public GameObject waterDrop;
	public int waterCount;
	private int maxCount;
	public GameObject waterParent;
	public GameObject liftParent;
	public GameObject liftTop;
	public GameObject waterPFX;
	private int waterPFXCounter;
	// Use this for initialization
	void Start () {
		maxCount=waterCount;
		waterPFXCounter=0;
	}
	
	// Update is called once per frame
	void Update () {
		float waterHeight=((1f*waterCount)/maxCount)*43f;
		waterParent.transform.localScale=new Vector3(1,waterHeight,1);
		float topHeight=((maxCount-1f*waterCount)/maxCount)*17.48f;
		topHeight-=9.68f;
		liftTop.transform.localPosition=new Vector3(0,topHeight,0);
		float liftHeight=((maxCount-1f*waterCount)/maxCount)*118f;
		liftParent.transform.localScale=new Vector3(1,liftHeight+2,1);

		//transform.localScale=new Vector3(16*((float)waterCount/(float)maxCount),1,1);
		//waterPFX.SetActive(false);
		if (Input.GetMouseButton(0) && waterCount>0) {
			
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit, 500) ) {
				if(hit.point.x>-80 && hit.point.x<80 && hit.point.y>80 && hit.point.y<100){
					GameObject temp=(GameObject)Instantiate(waterDrop,hit.point,transform.rotation);

					temp.transform.position= new Vector3(temp.transform.position.x+Random.Range(-5,5),temp.transform.position.y+Random.Range(-5,5),0);
					temp.GetComponent<Rigidbody>().velocity=new Vector3(Random.Range(-5,5),Random.Range(-5,5),0);
					waterCount--;
					waterPFXCounter=30;
					if(!waterPFX.activeSelf)waterPFX.SetActive(true);
					if(!waterPFX.transform.GetComponent<ParticleSystem>().isPlaying)
					waterPFX.transform.GetComponent<ParticleSystem>().Play();
				}
			}
		}

		if(waterPFXCounter>0){
			waterPFXCounter--;
			if(!waterPFX.transform.GetComponent<ParticleSystem>().isPlaying)
				waterPFX.transform.GetComponent<ParticleSystem>().Play();
		}
		else{
			waterPFX.transform.GetComponent<ParticleSystem>().Stop();
			if(waterPFX.transform.GetComponent<ParticleSystem>().particleCount<=0){
				waterPFX.SetActive(false);
			}
		}
	}
}
