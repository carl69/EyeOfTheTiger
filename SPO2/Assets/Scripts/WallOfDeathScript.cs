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
            if (notDriveAtNight)
            {
                if (clockScript.isDay)
                {
                    if (hasStarted == false)
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
                if (hasStarted == false)
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
	}
    
}
