﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CanvasController : MonoBehaviour {

    public GameObject textBox;
    public Transform curChild;

    public AudioClip hoverMouseClip;
    public AudioSource hoverAudioSource;

    public Button resume;

    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            resume = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Button>();
        }

        if(GameObject.FindGameObjectWithTag("Player") != null && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>() != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>().texts = GameObject.FindGameObjectWithTag("TextPrompts");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>().Resume = resume;
        }
  
        hoverAudioSource = GameObject.Find("MouseHover").GetComponent<AudioSource>();
        if (GameObject.FindGameObjectWithTag("TextPrompts") != null)
        {
            textBox = GameObject.FindGameObjectWithTag("TextPrompts");
            textBox.SetActive(false);
        }

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
        PlayerPrefs.SetFloat("Food", 0);
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
        Time.timeScale = 1;
        Debug.Log("MainMenu clicked!");
        SceneManager.LoadScene("MainMenu");     
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void MouseHover()
    {
        if (!hoverAudioSource.isPlaying && resume.IsInteractable())
        {     
                    hoverAudioSource.PlayOneShot(hoverMouseClip);
        }
    }

    public void OnMouseExit()
    {
        hoverAudioSource.Stop();
    }

    public void Continue()
    {


        PlayerPrefs.SetInt("Den", 1);
        PlayerPrefs.SetInt("Cub", 0);
        PlayerPrefs.SetString("CubName", "");

        SceneManager.LoadScene("Den"+"0"+PlayerPrefs.GetInt("Home"));
    }

    public void Retry()
    {
        PlayerPrefs.SetInt("Home",0);
        PlayerPrefs.SetInt("Days", 0);
        PlayerPrefs.SetInt("Den", 0);
        PlayerPrefs.SetInt("Cub", 0);
        PlayerPrefs.SetInt("StoredFood", 0);
        PlayerPrefs.SetFloat("Food",0);
        PlayerPrefs.SetString("CubName", "");

        SceneManager.LoadScene("Den00");
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