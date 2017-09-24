using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {
	public bool hidden = false;
	private bool hiden = false;
	private Renderer[] renderChildren;
	// Use this for initialization
	void Start () {
		//finds child objects
		renderChildren = GetComponentsInChildren<Renderer>();
	}

	// Update is called once per frame
	void Update () {

		if (hiden == true && Input.GetKey (KeyCode.Space)) {
			intoHide ();
		} else {
			outoHide();
		}

	}

	private void OnTriggerEnter (Collider other)
	{

		if (other.gameObject.tag == "Bush")
		{
			hiden = true;
		}
	}
	private void OnTriggerExit(Collider collision)
	{
		if (collision.gameObject.tag == "Bush")
		{
			hiden = false;
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
		hidden = false;
		foreach (Renderer r in renderChildren)
		{
			r.enabled = true;
		}
	}

}
