﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {

    public GameObject textBox;
    public Transform curChild;

    // Use this for initialization
    void Start()
    {
        textBox = GameObject.FindGameObjectWithTag("TextPrompts");
        textBox.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Debug.Log("Resume clicked!");
        textBox.SetActive(false);
          
    }

    public void Play()
    {
        PlayerPrefs.SetInt("Home", 0);
        PlayerPrefs.SetInt("Den", 0);
        PlayerPrefs.SetInt("Cub", 0);
        PlayerPrefs.SetInt("StoredFood", 0);
        PlayerPrefs.SetFloat("Food", 5);
        PlayerPrefs.SetInt("Days", 0);
        PlayerPrefs.SetString("CubName", "");

        int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(y + 1);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                textBox.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                textBox.SetActive(false);
                Time.timeScale = 1;
            }
        }
        //if (textBox.activeSelf == false)
        //{
        //    Time.timeScale = 1;
        //}
    }
}