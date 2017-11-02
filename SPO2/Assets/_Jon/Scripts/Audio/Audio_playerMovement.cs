using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_playerMovement : MonoBehaviour {

    public AudioClip walk;
    public AudioClip run;

    public bool isWalking = false;
    public bool isRunning = false;

    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
    void GetState()
    {
        if(Input.GetAxis("Horizontal") !=0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //Running
                isWalking = false;
                isRunning = true;
            }
            else
            {
                //Walking
                isWalking = true;
                isRunning = false;
            }
        }
        else
        {
            //Stopped
            isWalking = false;
            isRunning = false;
        }
  
    }

    void PlayAudio()
    {
        if (isWalking)
        {
            if(GetComponent<AudioSource>().clip != walk)
            {
                source.Stop();
                source.clip = walk;
            }
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
        else if( isRunning == true)
        {
            if(source.clip != run)
            {
                source.Stop();
                source.clip = run;
            }
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
        else
        {
            source.Stop();
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
