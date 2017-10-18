using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour {
    public GameObject pray;
    Clock_24Hour Clock24Hour;
    private GameObject Clock;
    private bool spawnOne;
	// Use this for initialization
	void Start () {
        Clock = GameObject.Find("24HourClock");
        Clock24Hour = Clock.GetComponent<Clock_24Hour>();



        var gos = Instantiate(pray);
        gos.transform.parent = this.gameObject.transform;
        gos.transform.position = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Clock24Hour.isDay == true && spawnOne)
        {
            spawnOne = false;

            var gos = Instantiate(pray);
            gos.transform.parent = this.gameObject.transform;
            gos.transform.position = this.transform.position;
        }
        if (Clock24Hour.isNight == true)
        {
            spawnOne = true;
        }
	}
}
