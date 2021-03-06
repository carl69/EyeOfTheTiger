﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour {
    private Animator FallingTree;

    public AudioClip[] fallingAudio;

	// Use this for initialization
	void Start () {
        FallingTree = GetComponent<Animator>();
        FallingTree.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tree" || other.tag == "TreeCutter" || other.tag == "WallofDeath")
        {
            FallingTree.enabled = true;
            GetComponent<AudioSource>().PlayOneShot(fallingAudio[Random.Range(0, 4)]);
        }
        if (other.gameObject.layer == 10)
        {
            Destroy(this);
            FallingTree.enabled = false;
        }
    }
}
