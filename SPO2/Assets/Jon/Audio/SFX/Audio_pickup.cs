using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_pickup : MonoBehaviour {

    public AudioClip food;
    public AudioClip water;

    public bool isEating = false;

    PlayerWater playerWater;

	// Use this for initialization
	void Start () {

        playerWater = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWater>();

	}


    // Update is called once per frame
    void Update () {

        if (isEating == true)
        {
            transform.GetChild(0).GetComponent<AudioSource>().GetComponent<AudioSource>().PlayOneShot(food);
            isEating = false;
        }
        if(playerWater.drinkAudio == true && transform.GetChild(1).GetComponent<AudioSource>().isPlaying == false)
        {
            transform.GetChild(1).GetComponent<AudioSource>().PlayOneShot(water);
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(2).gameObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Player").transform.GetChild(2).gameObject, 2f);
        }
	}
}
