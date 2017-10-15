using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_parkRanger : MonoBehaviour {

    private bool hasTriggered = false;
    public GameObject ParkRanger;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && hasTriggered == false)
        {
            Debug.Log("Park Ranger activated!");
            ParkRanger.SetActive(true);
            hasTriggered = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
