using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvl01_endTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("TextPrompts").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("TextPrompts").transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "You escaped with your life deeper into the forest.";
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
