using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_transitions : MonoBehaviour {

    public string currentScene;

    private IEnumerator transition;

    public float newFadeDirection;

    public GameObject cam;

	// Use this for initialization
	void Start () {

        currentScene = SceneManager.GetActiveScene().name;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        newFadeDirection = -1.0f;

    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player" && currentScene == "Den00")
        {
            cam.GetComponent<CameraFade>().fadeDir = newFadeDirection;
            StartCoroutine(SceneTransition00());          
        }
        else if (other.gameObject.tag == "Player")
        {
            cam.GetComponent<CameraFade>().fadeDir = newFadeDirection;
            StartCoroutine(SceneTransition01());            
        }

    }

    public IEnumerator SceneTransition00()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(5f);
        Debug.Log("3 seconds passed");
        SceneManager.LoadScene("WorldMap");
    }

    public IEnumerator SceneTransition01()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(5f);
        Debug.Log("3 seconds passed");
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(y + 1);
    }
    
    // Update is called once per frame
    void Update () {
		
	}
}
