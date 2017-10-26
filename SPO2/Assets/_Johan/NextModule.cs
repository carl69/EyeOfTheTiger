using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextModule : MonoBehaviour {
    GameObject levelGenerator;
    public GameObject moduleTarget;
    public int moduleLength;

    // Use this for initialization
    void Start () {
        levelGenerator = GameObject.Find("LevelGenerator");
        if (levelGenerator.GetComponent<LevelGenerator>().levelLength>0)
        {
            levelGenerator.GetComponent<LevelGenerator>().levelLength -= moduleLength;
            levelGenerator.GetComponent<LevelGenerator>().GenerateNextModule();
            //Instantiate(levelGenerator.GetComponent<LevelGenerator>().modules[Random.Range(0, levelGenerator.GetComponent<LevelGenerator>().modules.Length)], moduleTarget.transform.position, moduleTarget.transform.rotation);
        }
       /* if(levelGenerator.GetComponent<LevelGenerator>().levelLength <= 0)
        {
            Instantiate(Controller.GetComponent<LevelGenerator>().modules[Random.Range(0, levelGenerator.GetComponent<LevelGenerator>().modules.Length)], gameObject.transform.position, gameObject.transform.rotation);
        }*/
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
