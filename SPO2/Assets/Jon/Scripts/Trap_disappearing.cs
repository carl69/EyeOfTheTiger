using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_disappearing : MonoBehaviour {

    public bool trapSprung = false;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && trapSprung == false)
        {
            GetComponent<AudioSource>().Play();
            Destroy(transform.GetChild(0).gameObject);
            trapSprung = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
