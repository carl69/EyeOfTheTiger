using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public int levelLength;
    public int difficultyLevel;

    int whatKindOfModueShouldBeLoaded;
    public GameObject[] modules;


    public GameObject[] startingModules;
    public GameObject[] finishingModules;

    public GameObject[] denModules;
    public GameObject[] poacherModules;
    public GameObject[] resourceModules;
    

    // Use this for initialization
    void Start () {
        //modules = Resources.LoadAll<GameObject>("Modules") as GameObject[];
        //Instantiate(modules[Random.Range(0, modules.Length)], gameObject.transform.position, gameObject.transform.rotation);
        GenerateNextModule();
    }

    public void GenerateNextModule()
    {
        whatKindOfModueShouldBeLoaded = Random.Range(1, 100);
        if (difficultyLevel == 1)
        {
            denModules = Resources.LoadAll<GameObject>("Modules/Difficulty1/Den") as GameObject[];
            poacherModules = Resources.LoadAll<GameObject>("Modules/Difficulty1/Poacher") as GameObject[];
            resourceModules = Resources.LoadAll<GameObject>("Modules/Difficulty1/Resources") as GameObject[];

            if (whatKindOfModueShouldBeLoaded <= 10 && whatKindOfModueShouldBeLoaded >= 1)
            {
                Instantiate(denModules[Random.Range(0, denModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
            }
            if (whatKindOfModueShouldBeLoaded <= 11 && whatKindOfModueShouldBeLoaded >= 40)
            {
                Instantiate(poacherModules[Random.Range(0, poacherModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
            }
            if (whatKindOfModueShouldBeLoaded <= 41 && whatKindOfModueShouldBeLoaded >= 100)
            {
                Instantiate(resourceModules[Random.Range(0, resourceModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
            }

        }
        if (difficultyLevel == 2)
        {
            denModules = Resources.LoadAll<GameObject>("Modules/Difficulty2/Den") as GameObject[];
            poacherModules = Resources.LoadAll<GameObject>("Modules/Difficulty2/Poacher") as GameObject[];
            resourceModules = Resources.LoadAll<GameObject>("Modules/Difficulty2/Resources") as GameObject[];

            if (whatKindOfModueShouldBeLoaded <= 10 && whatKindOfModueShouldBeLoaded >= 1)
            {
                Instantiate(denModules[Random.Range(0, denModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
            }
            if (whatKindOfModueShouldBeLoaded <= 11 && whatKindOfModueShouldBeLoaded >= 40)
            {
                Instantiate(poacherModules[Random.Range(0, poacherModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
            }
            if (whatKindOfModueShouldBeLoaded <= 41 && whatKindOfModueShouldBeLoaded >= 100)
            {
                Instantiate(resourceModules[Random.Range(0, resourceModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
            }
        }
        if (difficultyLevel == 3)
        {
            denModules = Resources.LoadAll<GameObject>("Modules/Difficulty3/Den") as GameObject[];
            poacherModules = Resources.LoadAll<GameObject>("Modules/Difficulty3/Poacher") as GameObject[];
            resourceModules = Resources.LoadAll<GameObject>("Modules/Difficulty3/Resources") as GameObject[];

            if (whatKindOfModueShouldBeLoaded <= 10 && whatKindOfModueShouldBeLoaded >= 1)
            {
                Instantiate(denModules[Random.Range(0, denModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
            }
            if (whatKindOfModueShouldBeLoaded <= 11 && whatKindOfModueShouldBeLoaded >= 40)
            {
                Instantiate(poacherModules[Random.Range(0, poacherModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
            }
            if (whatKindOfModueShouldBeLoaded <= 41 && whatKindOfModueShouldBeLoaded >= 100)
            {
                Instantiate(resourceModules[Random.Range(0, resourceModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
            }
        }
    }
}
