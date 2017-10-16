using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Triggers : MonoBehaviour {

    public string triggerNumber;


	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Mother" && triggerNumber == "1")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 3f);
        }
        if(other.gameObject.tag == "Mother" && triggerNumber == "2")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 3f);
            
        }
        if (other.gameObject.tag == "Mother" && triggerNumber == "3")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 2f);

        }
        if (other.gameObject.tag == "Pray" && triggerNumber == "4")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 3f);
        }
        if (other.gameObject.tag == "Player" && triggerNumber == "5")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 2f);
        }
        if (other.gameObject.tag == "Mother" && triggerNumber == "6")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 2f);
        }
        if (other.gameObject.tag == "Mother" && triggerNumber == "7")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            Destroy(gameObject, 2f);
        }


    }

    // Update is called once per frame
    void Update () {
		
	}
}
