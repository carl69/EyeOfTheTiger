using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;

public class Player_movement : MonoBehaviour {

    [EventRef]
    public string footstepSound = "event:/Footsteps";
    public string runningSound = "event:/Running";
    private FMOD.Studio.EventInstance footstepSFX;
    private FMOD.Studio.EventInstance runningSFX;


    public bool isRunning = false;
    public bool isWalking = false;

	// Use this for initialization
	void Start () {
        footstepSFX = RuntimeManager.CreateInstance(footstepSound);
        runningSFX = RuntimeManager.CreateInstance(runningSound);
    }
	
    public void playFootsteps()
    {
        footstepSFX.setParameterValue("PlayerWalking", 1f);
        footstepSFX.start();
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(footstepSFX, gameObject.transform, GetComponent<Rigidbody>());
    }
    public void playRunning()
    {
        runningSFX.setParameterValue("PlayerRunning", 1f);
        runningSFX.start();
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(runningSFX, gameObject.transform, GetComponent<Rigidbody>());
    }
    public void stopFootsteps()
    {
        footstepSFX.setParameterValue("PlayerNotWalking", 1f);
        footstepSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
    public void stopRunning()
    {
        runningSFX.setParameterValue("PlayerNotRunning", 1f);
        runningSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

	// Update is called once per frame
	void Update () {
		if((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && !Input.GetKey(KeyCode.LeftShift) && isWalking == false)
        {
            isWalking = true;
            playFootsteps();
        }
        if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            isRunning = false;
            isWalking = false;
            stopFootsteps();
            stopRunning();
        }
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Input.GetKey(KeyCode.LeftShift) && isRunning == false)
        {
            isRunning = true;
            isWalking = false;
            stopFootsteps();
            playRunning();
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = false;
            stopRunning();
        }
    } 	
}
