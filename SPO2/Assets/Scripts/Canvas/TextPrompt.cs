using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextPrompt : MonoBehaviour {
    

    public string triggerNumber;

    public GameObject textBox;
   // public CanvasTest boolToCheck;

    public bool text1Shown = false;
    public bool text2Shown = false;
    public bool text3Shown = false;
    public bool text4Shown = false;
    public bool text5Shown = false;
    public bool text6Shown = false;
    public bool text7Shown = false;
    public bool text8Shown = false;



    // Use this for initialization
    void Start () {

       

        	
	}

    private void OnTriggerEnter(Collider collision)
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
        if (collision.gameObject.tag == "Player" && triggerNumber == "3" && text3Shown == false)
        {
            textBox.SetActive(true);
            textBox.transform.GetChild(2).gameObject.SetActive(true);
            text3Shown = true;
            Time.timeScale = 0;
        }
        if (collision.gameObject.tag == "Player" && triggerNumber == "4" && text4Shown == false)
        {
            textBox.SetActive(true);
            textBox.transform.GetChild(3).gameObject.SetActive(true);
            text4Shown = true;
            Time.timeScale = 0;
        }
        if (collision.gameObject.tag == "Player" && triggerNumber == "5" && text5Shown == false)
        {
            textBox.SetActive(true);
            textBox.transform.GetChild(4).gameObject.SetActive(true);
            text5Shown = true;
            Time.timeScale = 0;
        }
        if (collision.gameObject.tag == "Player" && triggerNumber == "6" && text6Shown == false)
        {
            textBox.SetActive(true);
            textBox.transform.GetChild(5).gameObject.SetActive(true);
            text6Shown = true;
            Time.timeScale = 0;
        }
        if (collision.gameObject.tag == "Player" && triggerNumber == "7" && text7Shown == false)
        {
            textBox.SetActive(true);
            textBox.transform.GetChild(6).gameObject.SetActive(true);
            text7Shown = true;
            Time.timeScale = 0;
        }
        if (collision.gameObject.tag == "Player" && triggerNumber == "8" && text8Shown == false)
        {
            textBox.SetActive(true);
            textBox.transform.GetChild(7).gameObject.SetActive(true);
            text8Shown = true;
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
