using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkRangerAppears : MonoBehaviour {
    public int neededIntToCome;
    ParkRanger PR;
    GameObject Clock;
    Clock_24Hour Time;
    Renderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        PR = GetComponent<ParkRanger>();
        Clock = GameObject.FindGameObjectWithTag("Clock");
        Time = Clock.GetComponent<Clock_24Hour>();
	}
	
	// Update is called once per frame
	void Update () {
        if (neededIntToCome <= Time.day && PR.enabled == true)
        {
            rend.enabled = false;
            PR.enabled = false;
        }
        else if(rend.enabled == true)
        {
            rend.enabled = true;
            PR.enabled = true;
        }
	}
}
