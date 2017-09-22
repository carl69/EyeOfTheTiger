using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    public GameObject textBox;

	// Use this for initialization
	void Start () {
		
	}

   public void Continue()
    {
        Debug.Log("Button clicked!");
        Time.timeScale = 1;
        gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);  
        textBox.SetActive(false);
    }


	// Update is called once per frame
	void Update () {
		
	}
}
