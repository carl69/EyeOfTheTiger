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
        SceneManager.LoadScene("Level02");
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            textBox.SetActive(true);
            Time.timeScale = 0;
        }
    }
}