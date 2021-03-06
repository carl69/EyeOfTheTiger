﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour {

    private bool day1tipShown = false;

    public GameObject day01Tip;
    public GameObject instructions01;
    public GameObject instructions02;
    public GameObject instructions03;

    public GameObject mapTip01;
    public GameObject mapTip02;

    public bool mapTipShown = false;

    public GameObject food;
    public GameObject tut01tip01;
    public GameObject playerUI;
    public bool hasEaten = false;
    public bool turnInstructions03Off = false;

    public AudioSource ToolTipSource;
    public AudioClip ToolTipClip;
    public bool soundHasPlayed = false;

    // Use this for initialization
    void Start () {
		if(SceneManager.GetActiveScene().name == "WorldMap" && PlayerPrefs.GetInt("Days") == 0)
        {
            mapTip01.SetActive(true);
            ToolTipSource = gameObject.GetComponent<AudioSource>();
        }
        ToolTipSource = gameObject.GetComponent<AudioSource>();
        soundHasPlayed = false;
        mapTipShown = false;
    }
	
	// Update is called once per frame
	void Update () {

		if(PlayerPrefs.GetInt("Days") == 1 && SceneManager.GetActiveScene().name == "Den00" && day1tipShown == false)
        {
            day1tipShown = true;
            day01Tip.SetActive(true);
            if (ToolTipSource.isPlaying == false && soundHasPlayed == false)
            {
                ToolTipSource.PlayOneShot(ToolTipClip);
                soundHasPlayed = true;
            }
        }
        if(PlayerPrefs.GetInt("Days") > 0 && SceneManager.GetActiveScene().name == "Den00")
        {
            instructions01.SetActive(false);
            instructions02.SetActive(false);
        }
        if(PlayerPrefs.GetInt("Den") == 1 && SceneManager.GetActiveScene().name == "Den00" && turnInstructions03Off == false)
        {

            instructions03.SetActive(true);
            if (ToolTipSource.isPlaying == false && soundHasPlayed == false)
            {
                ToolTipSource.PlayOneShot(ToolTipClip);
                soundHasPlayed = true;
            }
            turnInstructions03Off = true;
        }
        if(SceneManager.GetActiveScene().name == "WorldMap")
        {
            if(PlayerPrefs.GetInt("Days") == 1)
            {
                if (mapTipShown == false)
                {
                    mapTip02.SetActive(true);
                    mapTipShown = true;
                }
                if (ToolTipSource.isPlaying == false && soundHasPlayed == false)
                {
                    ToolTipSource.PlayOneShot(ToolTipClip);
                    soundHasPlayed = true;
                }
            }
        }
        if(SceneManager.GetActiveScene().name == "Tutorial_1" && food == null && hasEaten == false)
        {
            hasEaten = true;
            tut01tip01.SetActive(true);
            if (ToolTipSource.isPlaying == false && soundHasPlayed == false)
            {
                ToolTipSource.PlayOneShot(ToolTipClip);
                soundHasPlayed = true;
            }
            playerUI.SetActive(true);
        }
	}
}
