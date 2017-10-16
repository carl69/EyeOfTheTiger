using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poacher_triggerDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemie")
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemie"));
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
