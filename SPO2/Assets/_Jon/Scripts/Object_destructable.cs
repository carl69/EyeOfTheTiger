using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_destructable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "WallofDeath")
        {
            Destroy(gameObject, 1f);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
