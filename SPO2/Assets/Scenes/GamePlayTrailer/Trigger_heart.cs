using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_heart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(transform.GetChild(0).gameObject, 4f);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
