using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdCameraOnStart : MonoBehaviour {
    public bool UseThisScript = false;
    public float WaitToStart = 2;
    public FollowCamera CameraFollowScript;
    private float curTime;
	// Use this for initialization
	void Start () {
        if (UseThisScript)
        {
            CameraFollowScript.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (curTime > WaitToStart)
        {
            CameraFollowScript.enabled = true;
            Destroy(this);
        }
        else
        {
            curTime += 1 * Time.deltaTime;
        }
	}
}
