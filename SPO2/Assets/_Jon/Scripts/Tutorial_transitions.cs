using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_transitions : MonoBehaviour {

    public string currentScene;

	// Use this for initialization
	void Start () {
        currentScene = SceneManager.GetActiveScene().name;
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && currentScene == "Tutorial_3")
        {
            SceneManager.LoadScene("Tutorial_4");         
        }
        else if (other.gameObject.tag == "Player")
        {
            int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(y + 1);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
