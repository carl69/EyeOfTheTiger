using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPlayerprefsOfTheLevelForTheDen : MonoBehaviour {
    public int playprefs;
    public bool usethehack = false;
    PlayerPayingFoodToThisObject Script01;
    PlayerPayingFoodToThisObject script02;
    public GameObject Hive;
    // Use this for initialization
    void Start () {


        Script01 = GetComponent<PlayerPayingFoodToThisObject>();
        script02 = Hive.GetComponent<PlayerPayingFoodToThisObject>();



    }
	
	// Update is called once per frame
	void Update () {
        if (usethehack == true)
        {
            PlayerPrefs.SetInt("Den", playprefs);
        }

        if (PlayerPrefs.GetInt("Den") >= 1)
        {
            if (script02.enabled == true)
            {
                script02.PAY();
            }
        }
        if (PlayerPrefs.GetInt("Den") >= 2)
        {
            if (Script01.enabled == true)
            {
                Script01.PAY();
            }
        }
    }
}
