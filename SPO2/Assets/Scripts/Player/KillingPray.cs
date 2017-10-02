﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingPray : MonoBehaviour {
    public GameObject food;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider c)
    {
		if (c.tag == "Pray" && Input.GetKey (KeyCode.LeftShift))
        {
            Instantiate(food, new Vector3(c.transform.position.x, c.transform.position.y, c.transform.position.z), Quaternion.identity);
            Destroy(c.gameObject);
        }
    }
}
