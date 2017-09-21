using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_pickup : MonoBehaviour {

    public AudioClip food;
    public AudioClip water;

	// Use this for initialization
	void Start () {
		
	}

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "food" && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<AudioSource>().PlayOneShot(food);
        }
        else if (other.gameObject.tag == "water" && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<AudioSource>().PlayOneShot(water);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
