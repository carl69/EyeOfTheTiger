using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_01_EnemyTrigger : MonoBehaviour {

    public AudioClip musicTension;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemie")
        {
            transform.GetChild(0).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("AudioController").transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().Stop();
            GameObject.FindGameObjectWithTag("AudioController").transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(musicTension);
            transform.GetChild(1).gameObject.SetActive(true);
            Destroy(transform.GetChild(1).gameObject, 5f);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
