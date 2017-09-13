using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("2");

        if (other.tag == "Bush")
        {
            intoHide();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Bush")
        {
            outoHide();
        }
    }


    public void intoHide()
    {
        Debug.Log("in");
    }
    public void outoHide()
    {
        Debug.Log("out");
    }

}
