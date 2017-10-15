using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScreen_continue : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	


	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(y + 1);
        }
	}
}
