﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Trap")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
