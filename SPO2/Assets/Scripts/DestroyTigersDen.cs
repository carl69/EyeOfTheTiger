using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyTigersDen : MonoBehaviour {
	private GameObject workingDen;
	private GameObject DestroyedDen;
	WallOfDeathScript stopedBull;
	public bool stop = true;

	public int day, day2;
	public GameObject clock;
	public Clock_24Hour clockScript;
	public bool haveClockInTheScene;

	// Use this for initialization
	void Start () {
		workingDen = this.gameObject.transform.GetChild(0).gameObject;
		DestroyedDen = this.gameObject.transform.GetChild(1).gameObject;



		clock = GameObject.FindGameObjectWithTag("Clock");
		clockScript = clock.GetComponent<Clock_24Hour>();
	}

	// Update is called once per frame
	void Update () {
		day = clockScript.day;
		if (!stop && day == day2) {
			workingDen.SetActive(false);
			DestroyedDen.SetActive(true);
			Destroy (this.gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "WallofDeath" && stop) {
			stop = false;
			day2 = clockScript.day + 1;
		}
	}
}