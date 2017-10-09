using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_fadeOnTrigger : MonoBehaviour {

    public float fadeDirection = 1f;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().fadeDir = fadeDirection;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
