using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_fadeOnTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().fadeDir = 1f;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
