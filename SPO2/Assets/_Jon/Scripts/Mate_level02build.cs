using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mate_level02build : MonoBehaviour {

    public GameObject cubPrefab;
   
    public bool hasCub = false;

	// Use this for initialization
	void Start () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && hasCub == false)
        {
            cubPrefab.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
