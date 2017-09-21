using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {

    public AudioClip jump;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().PlayOneShot(jump);
        }

	}
}
