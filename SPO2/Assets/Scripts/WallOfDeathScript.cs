﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallOfDeathScript : MonoBehaviour {
    public float speed = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y,0);
	}

    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player" || c.tag == "Cub")
        {
            Debug.Log("restart");
            SceneManager.LoadScene("prototype");
        }
    }

}
