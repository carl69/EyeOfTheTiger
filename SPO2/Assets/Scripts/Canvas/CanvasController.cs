using System.Collections;
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

    }

    public void Resume()
    {
        Debug.Log("Resume clicked!");
        textBox.SetActive(false);
        Time.timeScale = 1;  
    }

    public void Play()
    {
         int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(y + 1);
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
                Time.timeScale = 0;
            }
            else
            {
                textBox.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}