using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deforestation_start : MonoBehaviour {

    public bool playHorn = false;
    public AudioClip horn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (playHorn == true && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().PlayOneShot(horn);
            playHorn = false;
        }
        	
	}
}
