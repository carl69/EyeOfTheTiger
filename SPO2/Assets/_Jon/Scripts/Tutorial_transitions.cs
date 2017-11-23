using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_transitions : MonoBehaviour {

    public string currentScene;

    private IEnumerator transition;

    public float newCameraAlpha = 1;
    public float newFadeDirection =1;

	// Use this for initialization
	void Start () {
        currentScene = SceneManager.GetActiveScene().name;
        
	}

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player" && currentScene == "Den00")
        {
            StartCoroutine(SceneTransition());
           // SceneManager.LoadScene("WorldMap");
        }
        else if (other.gameObject.tag == "Player")
        {
            StartCoroutine(SceneTransition());
            //int y = SceneManager.GetActiveScene().buildIndex;
            //SceneManager.LoadScene(y + 1);
        }

    }

    public IEnumerator SceneTransition()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().alpha = newCameraAlpha;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().fadeDir = newFadeDirection;
        yield return new WaitForSeconds(2);


    } 

    // Update is called once per frame
    void Update () {
		
	}
}
