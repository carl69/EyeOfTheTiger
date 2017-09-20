using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

    public AudioClip footstep;

    public bool clipPlaying = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && (clipPlaying == false) && (GetComponent<AudioSource>().isPlaying == false))
        {
            GetComponent<AudioSource>().PlayOneShot(footstep);
           // clipPlaying = true;
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            clipPlaying = false;
        }
        
        }

        
       
       
           
        
                
                     

	
}
