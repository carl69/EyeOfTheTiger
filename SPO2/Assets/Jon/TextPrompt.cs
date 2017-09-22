using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextPrompt : MonoBehaviour {
    

    public string triggerNumber;

    public GameObject textBox;
   // public CanvasTest boolToCheck;

    public bool text1Shown = false;
    public bool text2Shown = false;

	// Use this for initialization
	void Start () {

       

        	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && triggerNumber == "1" && text1Shown == false)
        {
            textBox.SetActive(true);
            textBox.transform.GetChild(0).gameObject.SetActive(true);
            text1Shown = true;
            Time.timeScale = 0;

        }
        if (collision.gameObject.tag == "Player" && triggerNumber == "2" && text2Shown == false)
        {
            textBox.SetActive(true);
            textBox.transform.GetChild(1).gameObject.SetActive(true);
            text2Shown = true;
            Time.timeScale = 0;            
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
