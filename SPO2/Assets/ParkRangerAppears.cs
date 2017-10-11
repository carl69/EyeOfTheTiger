using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkRangerAppears : MonoBehaviour {
    public int neededIntToCome;
    ParkRanger PR;
    GameObject Clock;
    Clock_24Hour Time;
    Renderer rend;
    bool active = false;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        PR = GetComponent<ParkRanger>();
        Clock = GameObject.FindGameObjectWithTag("Clock");
        Time = Clock.GetComponent<Clock_24Hour>();
	}
	
	// Update is called once per frame
	void Update () {
        if (neededIntToCome >= Time.day && PR.enabled == true && active == false)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            rend.enabled = false;
            PR.enabled = false;
        }
        else if(Time.isDay  && rend.enabled != true)
        {
            active = true;
            transform.GetChild(0).gameObject.SetActive(true);
            rend.enabled = true;
            PR.enabled = true;
        }
	}
}
