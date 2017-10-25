using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearHunter : MonoBehaviour {

	DissappearHunter hunt;
	public float speed = 1;
	public float timeLeft = 5;

	public bool isPlayingAudio = false;
	private bool hasStarted = false;

	public GameObject clock, hunter;
	public Clock_24Hour clockScript;
	public bool haveClockInTheScene;

	public bool dia = false, create =  false;

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
		if (timeLeft < 0) {
			if (clockScript.isDay) {
				dia = true;
				if (create) {
					x = this.transform.position.x;
					y = this.transform.position.y;
					z = this.transform.position.z;
					var g = Instantiate (hunter, new Vector3 (x, y + 1 , z), /*Quaternion.Euler (0, 90, 0)*/ Quaternion.identity);
					g.transform.parent = gameObject.transform;
					create = false;
				}
			} else {
				dia = false;
				create = true;
			}
		} else {
			if (clockScript.isDay) {
				dia = true;
				if (create) {
					x = this.transform.position.x;
					y = this.transform.position.y;
					z = this.transform.position.z;
					var g = Instantiate (hunter, new Vector3 (x, y + 1 , z), /*Quaternion.Euler (0, 90, 0)*/ Quaternion.identity);
					g.transform.parent = gameObject.transform;
					create = false;
				}
			} else {
				dia = false;
				create = true;
			}
		}
	}


}
