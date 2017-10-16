using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_disappearing : MonoBehaviour {

    public bool trapSprung = false;
    Movement pMovement;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && trapSprung == false)
        {

            pMovement = other.gameObject.GetComponent<Movement>();
            pMovement.enabled = false;

            GetComponent<AudioSource>().Play();
            Destroy(transform.GetChild(0).gameObject, 0.5f);
            trapSprung = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
