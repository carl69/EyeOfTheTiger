using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPresets : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        transform.position = new Vector3(this.transform.position.x,4.7f,-20.8f); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
