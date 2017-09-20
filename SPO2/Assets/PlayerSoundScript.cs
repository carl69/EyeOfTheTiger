using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundScript : MonoBehaviour {

    public AudioClip[] Walking;
    AudioSource audioSource;
    private int walkingListSize;
	// Use this for initialization
	void Start () {
        walkingListSize = Walking.Length;

        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(walkingListSize);
        if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(Walking[Random.Range(0,walkingListSize)], Random.Range(0.7f,1));
        }
	}
}
