using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallOfDeathScript : MonoBehaviour {

    public float speed = 1;
    public float timeLeft = 5;

    public bool isPlayingAudio = false;
    private bool hasStarted = false;

    public GameObject clock;
    public Clock_24Hour clockScript;
    public bool notDriveAtNight = false;
    public bool haveClockInTheScene;

	public bool stop = false;
	public int day, day2;


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
		day = clockScript.day;
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
			if (stop && day == day2) {
				stop = false;
			}
            if (notDriveAtNight)
            {
				if (clockScript.isDay && !stop)
                {
                    if (hasStarted == false )
                    {
                        GameObject.Find("DeforestationStart").GetComponent<Deforestation_start>().playHorn = true;
                        hasStarted = true;
                    }
                    transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y, transform.position.z);
                    if (isPlayingAudio == false)
                    {
                        GetComponent<AudioSource>().Play();
                        isPlayingAudio = true;
                    }
                }
            }
            else
            {
				if (!stop) {
					if (hasStarted == false) {
						GameObject.Find ("DeforestationStart").GetComponent<Deforestation_start> ().playHorn = true;
						hasStarted = true;
					}
					transform.position = new Vector3 (transform.position.x + Time.deltaTime * speed, transform.position.y, transform.position.z);
					if (isPlayingAudio == false) {
						GetComponent<AudioSource> ().Play ();
						isPlayingAudio = true;
					}
				}
            }
        }
	}
    


	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "TigersDen") {
			stop = true;
			day2 = clockScript.day + 1;
		}

	}

}
