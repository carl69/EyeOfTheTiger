﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallOfDeathScript : MonoBehaviour {

    public float speed = 1;
    public float timeLeft = 5;

    public bool isPlayingAudio = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y, transform.position.z);
            if (isPlayingAudio == false)
            {
                GetComponent<AudioSource>().Play();
                isPlayingAudio = true;
            }
        }
	}
    
}
