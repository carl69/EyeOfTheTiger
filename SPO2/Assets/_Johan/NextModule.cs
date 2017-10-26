using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextModule : MonoBehaviour {
    GameObject levelGenerator;
    public GameObject nextModule;
    public int moduleLength;

    // Use this for initialization
    void Start () {
        levelGenerator = GameObject.Find("LevelGenerator");
        if (levelGenerator.GetComponent<LevelGenerator>().levelLength>0)
        {
            levelGenerator.GetComponent<LevelGenerator>().levelLength -= moduleLength;
            GenerateNextModule();
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
    public void GenerateNextModule()
    {
        levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded = Random.Range(1, 100);
        if (levelGenerator.GetComponent<LevelGenerator>().difficultyLevel == 1)
        {
            levelGenerator.GetComponent<LevelGenerator>().denModules = Resources.LoadAll<GameObject>("Modules/Difficulty1/Den") as GameObject[];
            levelGenerator.GetComponent<LevelGenerator>().poacherModules = Resources.LoadAll<GameObject>("Modules/Difficulty1/Poacher") as GameObject[];
            levelGenerator.GetComponent<LevelGenerator>().resourceModules = Resources.LoadAll<GameObject>("Modules/Difficulty1/Resources") as GameObject[];

            if (levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded <= 10 && levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded >= 1)
            {
                Instantiate(levelGenerator.GetComponent<LevelGenerator>().denModules[Random.Range(0, levelGenerator.GetComponent<LevelGenerator>().denModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
            }
            if (levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded >= 11 && levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded <= 40)
            {
                Instantiate(levelGenerator.GetComponent<LevelGenerator>().poacherModules[Random.Range(0, levelGenerator.GetComponent<LevelGenerator>().poacherModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
            }
            if (levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded >= 41 && levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded <= 100)
            {
                Instantiate(levelGenerator.GetComponent<LevelGenerator>().resourceModules[Random.Range(0, levelGenerator.GetComponent<LevelGenerator>().resourceModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
            }

        }
        if (levelGenerator.GetComponent<LevelGenerator>().difficultyLevel == 2)
        {
            levelGenerator.GetComponent<LevelGenerator>().denModules = Resources.LoadAll<GameObject>("Modules/Difficulty2/Den") as GameObject[];
            levelGenerator.GetComponent<LevelGenerator>().poacherModules = Resources.LoadAll<GameObject>("Modules/Difficulty2/Poacher") as GameObject[];
            levelGenerator.GetComponent<LevelGenerator>().resourceModules = Resources.LoadAll<GameObject>("Modules/Difficulty2/Resources") as GameObject[];

            if (levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded <= 10 && levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded >= 1)
            {
                Instantiate(levelGenerator.GetComponent<LevelGenerator>().denModules[Random.Range(0, levelGenerator.GetComponent<LevelGenerator>().denModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
            }
            if (levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded <= 11 && levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded >= 40)
            {
                Instantiate(levelGenerator.GetComponent<LevelGenerator>().poacherModules[Random.Range(0, levelGenerator.GetComponent<LevelGenerator>().poacherModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
            }
            if (levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded <= 41 && levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded >= 100)
            {
                Instantiate(levelGenerator.GetComponent<LevelGenerator>().resourceModules[Random.Range(0, levelGenerator.GetComponent<LevelGenerator>().resourceModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
            }
        }
        if (levelGenerator.GetComponent<LevelGenerator>().difficultyLevel == 3)
        {
            levelGenerator.GetComponent<LevelGenerator>().denModules = Resources.LoadAll<GameObject>("Modules/Difficulty3/Den") as GameObject[];
            levelGenerator.GetComponent<LevelGenerator>().poacherModules = Resources.LoadAll<GameObject>("Modules/Difficulty3/Poacher") as GameObject[];
            levelGenerator.GetComponent<LevelGenerator>().resourceModules = Resources.LoadAll<GameObject>("Modules/Difficulty3/Resources") as GameObject[];

            if (levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded <= 10 && levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded >= 1)
            {
                Instantiate(levelGenerator.GetComponent<LevelGenerator>().denModules[Random.Range(0, levelGenerator.GetComponent<LevelGenerator>().denModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
            }
            if (levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded <= 11 && levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded >= 40)
            {
                Instantiate(levelGenerator.GetComponent<LevelGenerator>().poacherModules[Random.Range(0, levelGenerator.GetComponent<LevelGenerator>().poacherModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
            }
            if (levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded <= 41 && levelGenerator.GetComponent<LevelGenerator>().whatKindOfModueShouldBeLoaded >= 100)
            {
                Instantiate(levelGenerator.GetComponent<LevelGenerator>().resourceModules[Random.Range(0, levelGenerator.GetComponent<LevelGenerator>().resourceModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
            }
        }
    }
}
