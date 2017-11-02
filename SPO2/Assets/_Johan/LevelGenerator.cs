using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public int whatModuleWasSupposedToBeLoaded;
    public int levelLength;
    public int difficultyLevel;

    public int whatKindOfModueShouldBeLoaded;

    GameObject[] startingModules;
    GameObject[] finishingModules;

    public GameObject[] poacherModules;
    public GameObject[] resourceModules;

    public int poacherChance;
    public int resourceChance;

    // Use this for initialization
    void Start () {
        GenerateNextModule();
    }

    public void GenerateNextModule()
    {
        if (difficultyLevel == 1)
        {
            poacherModules = Resources.LoadAll<GameObject>("Modules/Difficulty1/Poacher") as GameObject[];
            resourceModules = Resources.LoadAll<GameObject>("Modules/Difficulty1/Resources") as GameObject[];
        }
        if (difficultyLevel == 2)
        {
            poacherModules = Resources.LoadAll<GameObject>("Modules/Difficulty2/Poacher") as GameObject[];
            resourceModules = Resources.LoadAll<GameObject>("Modules/Difficulty2/Resources") as GameObject[];
        }
        if (difficultyLevel == 3)
        {
            poacherModules = Resources.LoadAll<GameObject>("Modules/Difficulty3/Poacher") as GameObject[];
            resourceModules = Resources.LoadAll<GameObject>("Modules/Difficulty3/Resources") as GameObject[];
        }

        whatKindOfModueShouldBeLoaded = Random.Range(1, poacherChance + resourceChance);

            
        //choose type of module
        if (whatKindOfModueShouldBeLoaded <= poacherChance)
        {
            whatModuleWasSupposedToBeLoaded = Random.Range(0, poacherModules.Length);
            Instantiate(poacherModules[Random.Range(0, poacherModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
            print("paochieros in sight");
        }
        else if (whatKindOfModueShouldBeLoaded > poacherChance)
        {
            whatModuleWasSupposedToBeLoaded = Random.Range(0, resourceModules.Length);
            Instantiate(resourceModules[Random.Range(0, resourceModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
            print("Water! ..... or food...");
        }
    }
}
