using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {
    public bool hidden = false;

    private Renderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D (Collider2D other)
    {

        if (other.gameObject.tag == "Bush")
        {
            intoHide();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bush")
        {
            outoHide();
        }
    }


    public void intoHide()
    {
        rend.enabled = false;
        hidden = true;
    }
    public void outoHide()
    {
        rend.enabled = true;
        hidden = false;
    }

}
