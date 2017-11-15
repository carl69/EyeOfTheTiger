using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubLevelingUpPlayprefsLevling : MonoBehaviour {

    GameObject CubSceneManager;
    CubSceneManager script;
	// Use this for initialization
	void Start () {
        CubSceneManager = GameObject.FindGameObjectWithTag("SceneManager");
        script = CubSceneManager.GetComponent<CubSceneManager>();

        if (script.CubLevel == 0)
        {
            if (this.gameObject.name == "BabiCub")
            {
                script.CubLevel = 1;
            }
        }
        else if (script.CubLevel == 1)
        {
            if (this.gameObject.name == "Cub")
            {
                script.CubLevel = 2;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
