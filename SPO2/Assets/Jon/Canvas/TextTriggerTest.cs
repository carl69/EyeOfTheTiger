using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTriggerTest : MonoBehaviour {
    public GameObject textBox;

	// Use this for initialization
	void Start () {

        textBox = GameObject.FindGameObjectWithTag("TextPrompts");
	}


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textBox.transform.GetChild(0).gameObject.SetActive(true);
            
            textBox.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "New text written here in code";
                     
            Time.timeScale = 0;

        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
