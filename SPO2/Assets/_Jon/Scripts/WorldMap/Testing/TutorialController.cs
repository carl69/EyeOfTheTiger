using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour {

    private bool tip01Shown = false;

    public GameObject day01Tip;
    public GameObject instructions01;
    public GameObject instructions02;
    public GameObject instructions03;

    public GameObject mapTip01;
    public GameObject mapTip02;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("Days") == 1 && tip01Shown == false && SceneManager.GetActiveScene().name == "Tutorial_3")
        {
            tip01Shown = true;
            day01Tip.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Days") > 0 && SceneManager.GetActiveScene().name == "Tutorial_3")
        {
            instructions01.SetActive(false);
            instructions02.SetActive(false);
        }
        if(PlayerPrefs.GetInt("Den") == 1 && SceneManager.GetActiveScene().name == "Tutorial_3")
        {
            instructions03.SetActive(true);
        }
        if(SceneManager.GetActiveScene().name == "Tutorial_4")
        {
            if(PlayerPrefs.GetInt("Days") > 0)
            {
                mapTip01.SetActive(false);
            }
            if(PlayerPrefs.GetInt("Days") == 1)
            {
                mapTip02.SetActive(true);
            }

        }
	}
}
