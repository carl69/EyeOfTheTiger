using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubNaming : MonoBehaviour {
    public GameObject Button;
    public GameObject NameField;
    public GameObject Text;
    public string Name;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetString("CubName") == "")
        {
            Button.SetActive(true);
            NameField.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Button.SetActive(false);
            NameField.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            if (Button.activeSelf == true)
            {
                NameComfirm();
            }
        }
	}
    public void NameComfirm()
    {
        Time.timeScale = 1;
        Name = Text.GetComponent<Text>().text;
        PlayerPrefs.SetString("CubName", Name);
        Button.SetActive(false);
        NameField.SetActive(false);
    }
}
