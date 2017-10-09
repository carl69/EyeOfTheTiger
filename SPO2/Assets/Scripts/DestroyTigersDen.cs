using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTigersDen : MonoBehaviour {
    private GameObject workingDen;
    private GameObject DestroyedDen;

	// Use this for initialization
	void Start () {
        workingDen = this.gameObject.transform.GetChild(0).gameObject;
        DestroyedDen = this.gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WallofDeath")
        {
            workingDen.SetActive(false);
            DestroyedDen.SetActive(true);
        }
    }
}
