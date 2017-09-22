using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_pickup : MonoBehaviour {

    public AudioClip food;
    public AudioClip water;

    public bool isEating = false;
    

	// Use this for initialization
	void Start () {

	}


    // Update is called once per frame
    void Update () {
		
        if (isEating == true)
        {
            transform.GetChild(0).GetComponent<AudioSource>().GetComponent<AudioSource>().PlayOneShot(food);
            isEating = false;
        }
        if(GameObject.Find("Player").GetComponent<PlayerWater>().drinking == true && transform.GetChild(1).GetComponent<AudioSource>().GetComponent<AudioSource>().isPlaying == false)
        {
            transform.GetChild(1).GetComponent<AudioSource>().GetComponent<AudioSource>().PlayOneShot(water);
           
        }
	}
}
