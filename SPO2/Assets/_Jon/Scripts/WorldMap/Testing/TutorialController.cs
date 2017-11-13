﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour {

    private bool tip01Shown = false;

    public GameObject day01Tip;
    public GameObject instructions01;
    public GameObject instructions02;
    public GameObject instructions03;

    public GameObject mapTip01;
    public GameObject mapTip02;

    public GameObject food;
    public GameObject tut01tip01;
    public bool hasEaten = false;

	// Use this for initialization
	void Start () {
		if(SceneManager.GetActiveScene().name == "WorldMap" && PlayerPrefs.GetInt("Days") == 0)
        {
            mapTip01.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Time stopped!");
        }
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Time.time);
		if(PlayerPrefs.GetInt("Days") == 1 && tip01Shown == false && SceneManager.GetActiveScene().name == "Tutorial_3")
        {
            tip01Shown = true;
            day01Tip.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Days") > 0 && SceneManager.GetActiveScene().name == "Tutorial_3")
        {
            instructions01.SetActive(false);
            instructions02.SetActive(false);
        }
        if(PlayerPrefs.GetInt("Den") == 1 && SceneManager.GetActiveScene().name == "Tutorial_3")
        {
            instructions03.SetActive(true);
        }
        if(SceneManager.GetActiveScene().name == "WorldMap")
        {
            if(PlayerPrefs.GetInt("Days") == 1)
            {
                mapTip02.SetActive(true);
            }
        }
        if(SceneManager.GetActiveScene().name == "Tutorial_1" && food == null && hasEaten == false)
        {
            hasEaten = true;
            tut01tip01.SetActive(true);
        }
	}
}
