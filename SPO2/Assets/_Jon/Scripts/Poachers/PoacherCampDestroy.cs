using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoacherCampDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ParkRanger")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
