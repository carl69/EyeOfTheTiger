using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMapTransitionTo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered trigger!");
            SceneManager.LoadScene("WorldMap");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
