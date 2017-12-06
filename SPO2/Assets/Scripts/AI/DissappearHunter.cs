using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DissappearHunter : MonoBehaviour {

	public float speed = 1;
	public float timeLeft = 5;

	public bool isPlayingAudio = false;
	private bool hasStarted = false;

	public GameObject clock;
	public Clock_24Hour clockScript;
	public bool haveClockInTheScene;

	public bool dia = false;

	float x,y,z;
	// Use this for initialization
	void Start () {

		if (!clock && haveClockInTheScene)
		{
			clock = GameObject.FindGameObjectWithTag("Clock");
			clockScript = clock.GetComponent<Clock_24Hour>();
		}
	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0)
		{
			if (clockScript.isDay) {
				dia = true;

			} else {
				
				Destroy (this.gameObject);
			}
			} 
		if (!clockScript.isDay) {
			Destroy (this.gameObject);
		}
	}


}
