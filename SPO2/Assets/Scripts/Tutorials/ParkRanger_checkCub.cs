using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkRanger_checkCub : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered trigger!");
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 5f);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
