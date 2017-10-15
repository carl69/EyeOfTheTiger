using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {

    public GameObject textBox;
    public Transform curChild;

    public bool isPaused = false;

    // Use this for initialization
    void Start()
    {

    }

    public void Resume()
    {
        Debug.Log("Resume clicked!");
        textBox.SetActive(false);
        Time.timeScale = 1;  
    }

    public void Play()
    {
        SceneManager.LoadScene("Tutorial01");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
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
                isPaused = true;
                Time.timeScale = 0;
            }
            else
            {
                textBox.SetActive(false);
                isPaused = false;
                Time.timeScale = 1;
            }
            
        }
        
    }
}