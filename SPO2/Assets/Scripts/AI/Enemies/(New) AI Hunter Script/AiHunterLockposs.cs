using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHunterLockposs : MonoBehaviour {
    float lockinplace;
	// Use this for initialization
	void Start () {
        lockinplace = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, lockinplace);
	}
}
