﻿using UnityEngine;
using System.Collections;

public class KeepPlaying : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			transform.parent.parent.gameObject.SetActive (false);
		}
	}
}
