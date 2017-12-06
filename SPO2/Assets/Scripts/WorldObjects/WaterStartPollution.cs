using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStartPollution : MonoBehaviour {
    public GameObject Water;
    WaterPollution WaterP;
	// Use this for initialization
	void Start () {
        WaterP = Water.GetComponent<WaterPollution>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WallofDeath")
        {
            WaterP.wallOfDeath = other.gameObject;
            WaterP.startDecay = true;
        }
    }
}
