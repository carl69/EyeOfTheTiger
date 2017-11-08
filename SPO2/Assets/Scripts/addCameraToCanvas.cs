using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addCameraToCanvas : MonoBehaviour {
    Camera maincamera;
	// Use this for initialization
	void Start () {
       // maincamera = GameObject.FindGameObjectWithTag("MainCamera");
       maincamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Canvas canva = gameObject.GetComponent<Canvas>();

        canva.renderMode = RenderMode.ScreenSpaceCamera;
        canva.worldCamera = maincamera;

    
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
