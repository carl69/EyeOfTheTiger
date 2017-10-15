using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>().alpha = 0f;
            Debug.Log("Player triggered!");
            GameObject.FindGameObjectWithTag("TextPrompts").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("TextPrompts").transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = "The park ranger cleared a path for you. Proceed deeper into the forest. Maybe you'll be safe there.";

            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
