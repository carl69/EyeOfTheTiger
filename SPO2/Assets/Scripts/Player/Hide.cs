using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {
    public bool hidden = false;

    private Renderer[] renderChildren;
	// Use this for initialization
	void Start () {
        //rend = GetComponentInChildren<Renderer>();
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
        renderChildren = GetComponentsInChildren<Renderer>();
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
        foreach (Renderer r in renderChildren)
        {
            r.enabled = false;
        }
    }
    public void outoHide()
    {
        //rend.enabled = true;
        hidden = false;
        

        foreach (Renderer r in renderChildren)
        {
            r.enabled = true;
        }
    }

}
