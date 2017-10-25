using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public int levelLength;
    public GameObject[] modules;

	// Use this for initialization
	void Start () {
        modules = Resources.LoadAll<GameObject>("Modules") as GameObject[];
        Instantiate(modules[Random.Range(0, modules.Length)], gameObject.transform.position, gameObject.transform.rotation);
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void GenerateNextModule()
    {

    }
}
