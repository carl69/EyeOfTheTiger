using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkRanger_triggerStop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ParkRanger")
        {
            other.gameObject.GetComponent<ParkRanger>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
