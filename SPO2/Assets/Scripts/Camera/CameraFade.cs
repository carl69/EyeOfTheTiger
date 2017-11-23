using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFade : MonoBehaviour {

    public Texture2D fadeTexture;
    public float fadeSpeed;
    public int drawDepth = -1000;

    public float alpha;
    public float fadeDir;


    public void OnGUI()
    {
        alpha -= fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color()
        {
            a = alpha
        };

        GUI.depth = drawDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);



    }

    // Use this for initialization
    void Start () {

        fadeSpeed = 0.097f;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
