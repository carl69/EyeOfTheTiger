using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hide : MonoBehaviour {
	public bool hidden = false;
	private bool hiden = false;
	private Renderer[] renderChildren;
    private GameObject cub;

    Color color;
    // Use this for initialization
    void Start () {
        //color = 
        //finds if cub is in the game. finds the cub
        if (GameObject.Find("Cub") != null)
        {
            cub = GameObject.Find("Cub");
        }
		//finds child objects
		renderChildren = GetComponentsInChildren<Renderer>();
	}

	// Update is called once per frame
	void Update () {

		if (hiden == true /*&& Input.GetKey (KeyCode.C)*/) {
			intoHide ();
            gameObject.layer = 14;
            if (cub != null)
            {
                cub.layer = 14;
            }

        } else {
			outoHide();
            gameObject.layer = 8;
            if (cub != null)
            {
                cub.layer = 9;
            }
        }

    }

	private void OnTriggerStay (Collider other)
	{

		if (other.gameObject.tag == "Bush")
		{
			hiden = true;
		}
	}
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Bush")
        {
            hiden = false;
        }
    }


    public void intoHide()
	{
		foreach (Renderer r in renderChildren)
		{
            //r.enabled = false;
            if (r.GetComponent<SpriteRenderer>() != null)
            {
                Color tmp = r.GetComponent<SpriteRenderer>().color;
                tmp.a = 0.5f;
                r.GetComponent<SpriteRenderer>().color = tmp;

            }
            
        }
	}
	public void outoHide()
	{
		hidden = false;
		foreach (Renderer r in renderChildren)
		{
            if (r.GetComponent<SpriteRenderer>() != null)
            {
                Color tmp = r.GetComponent<SpriteRenderer>().color;
                tmp.a = 1f;
                r.GetComponent<SpriteRenderer>().color = tmp;
            }
                
        }
	}

}
