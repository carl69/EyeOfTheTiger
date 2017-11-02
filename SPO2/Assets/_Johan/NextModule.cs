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

    public GameObject[] emptyModules;
    public GameObject[] foodModules;
    public GameObject[] poacherCampModules;
    public GameObject[] poacherModules;
    public GameObject[] waterModules;

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
        moduleCategory = Random.Range(1, original.GetComponent<LevelGenerator>().staWaterChance);

        if (original.GetComponent<LevelGenerator>().moduleSetNumber == 1)
        {
            emptyModules = Resources.LoadAll<GameObject>("Modules/Set1/Empty") as GameObject[];
            foodModules = Resources.LoadAll<GameObject>("Modules/Set1/Food") as GameObject[];
            poacherCampModules = Resources.LoadAll<GameObject>("Modules/PoacherCamp/") as GameObject[];
            poacherModules = Resources.LoadAll<GameObject>("Modules/Set1/Poachers") as GameObject[];
            waterModules = Resources.LoadAll<GameObject>("Modules/Set1/Water") as GameObject[];
        }

        //choose type of module
        //empty module
        if (moduleCategory <= original.GetComponent<LevelGenerator>().staEmptyChance)
        {
            Instantiate(emptyModules[Random.Range(0, emptyModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
        }
        //food module
        else if (moduleCategory > original.GetComponent<LevelGenerator>().staEmptyChance && moduleCategory <= original.GetComponent<LevelGenerator>().staFoodChance)
        {
            Instantiate(foodModules[Random.Range(0, foodModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
        }
        //poacher camp module
        else if (moduleCategory > original.GetComponent<LevelGenerator>().staFoodChance && moduleCategory <= original.GetComponent<LevelGenerator>().staPoacherCampChance)
        {
            Instantiate(poacherCampModules[Random.Range(0, poacherCampModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
        }
        //poacher module
        else if (moduleCategory > original.GetComponent<LevelGenerator>().staPoacherCampChance && moduleCategory <= original.GetComponent<LevelGenerator>().staPoacherChance)
        {
            Instantiate(poacherModules[Random.Range(0, poacherModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
        }
        //water module
        else if (moduleCategory > original.GetComponent<LevelGenerator>().staPoacherChance && moduleCategory <= original.GetComponent<LevelGenerator>().staWaterChance)
        {
            Instantiate(waterModules[Random.Range(0, waterModules.Length)], nextModule.transform.position, nextModule.transform.rotation);
        }

        original.GetComponent<LevelGenerator>().levelLength -= moduleLength;
    }
}
