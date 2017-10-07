using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterCampScript : MonoBehaviour {

    public bool Guards;
    public bool Hunters;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Guards)
        {
            Gardians();
        }
        else {
            DevateGardians();
        }
        if (Hunters)
        {
            Huntiens();
        }
        else {
            DevateHuntiens();
        }
	}

    void Gardians()
    {
        transform.GetChild(0).gameObject.SetActive(true);

    }
    void DevateGardians()
    {
        transform.GetChild(0).gameObject.SetActive(false);

    }
    void Huntiens()
    {
        transform.GetChild(1).gameObject.SetActive(true);

    }
    void DevateHuntiens()
    {
        transform.GetChild(1).gameObject.SetActive(false);

    }

}
