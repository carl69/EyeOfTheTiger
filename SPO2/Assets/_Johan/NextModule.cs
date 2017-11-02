using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextModule : MonoBehaviour {
    GameObject original;
    public Transform nextModule;
    public int moduleLength;

    private int moduleCategory;

    GameObject[] startingModules;
    GameObject[] finishingModules;

    private GameObject[] poacherModules;
    private GameObject[] resourceModules;

    private int denChance;
    private int poacherChance;
    private int resourceChance;

    // Use this for initialization
    void Start () {
        nextModule = this.gameObject.transform.GetChild(0);
        original = GameObject.Find("LevelGenerator");
        if (original.GetComponent<LevelGenerator>().levelLength>0)
        {
            GenerateNextModule();
        }
    }
	
    void GenerateNextModule()
    {
        moduleCategory = Random.Range(1, original.GetComponent<LevelGenerator>().poacherChance + original.GetComponent<LevelGenerator>().resourceChance);

        if (original.GetComponent<LevelGenerator>().difficultyLevel == 1)
        {
            poacherModules = Resources.LoadAll<GameObject>("Modules/Difficulty1/Poacher") as GameObject[];
            resourceModules = Resources.LoadAll<GameObject>("Modules/Difficulty1/Resources") as GameObject[];
        }

        if (original.GetComponent<LevelGenerator>().difficultyLevel == 2)
        {
            poacherModules = Resources.LoadAll<GameObject>("Modules/Difficulty2/Poacher") as GameObject[];
            resourceModules = Resources.LoadAll<GameObject>("Modules/Difficulty2/Resources") as GameObject[];
        }
        if (original.GetComponent<LevelGenerator>().difficultyLevel == 3)
        {
            poacherModules = Resources.LoadAll<GameObject>("Modules/Difficulty3/Poacher") as GameObject[];
            resourceModules = Resources.LoadAll<GameObject>("Modules/Difficulty3/Resources") as GameObject[];
        }

        //choose type of module
        if (moduleCategory <= poacherChance)
        {
            moduleCategory = Random.Range(0, poacherModules.Length);
            Instantiate(poacherModules[Random.Range(0, poacherModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
            print("paochieros in sight");
        }
        if (moduleCategory > poacherChance)
        {
            moduleCategory = Random.Range(0, resourceModules.Length);
            Instantiate(resourceModules[Random.Range(0, resourceModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
            print("Water! ..... or food...");
        }

        original.GetComponent<LevelGenerator>().levelLength -= moduleLength;
    }
}
