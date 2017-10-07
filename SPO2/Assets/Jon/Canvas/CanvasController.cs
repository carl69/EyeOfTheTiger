using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {

    public GameObject textBox;
    public Transform curChild;


	// Use this for initialization
	void Start () {
		
	}

   public void Continue()
    {
        Debug.Log("Button clicked!");
        Time.timeScale = 1;
        for (int i = 0; i < textBox.transform.childCount; i++)
        {
            if(textBox.transform.GetChild(i).gameObject.activeSelf == true)
            {
                curChild = textBox.transform.GetChild(i);
            }
        }
        curChild.gameObject.SetActive(false);
        textBox.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Play()
    {
        SceneManager.LoadScene("Level02");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
