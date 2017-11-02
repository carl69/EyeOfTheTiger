using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    private int whatModuleWasSupposedToBeLoaded;
    public int levelLength;
    public int moduleSetNumber;

    int moduleCategory;

    GameObject[] startingModules;
    GameObject[] finishingModules;

    public GameObject[] emptyModules;
    public GameObject[] foodModules;
    public GameObject[] poacherCampModules;
    public GameObject[] poacherModules;
    public GameObject[] waterModules;

    public int emptyChance;
    public int foodChance;
    public int poacherCampChance;
    public int poacherChance;
    public int waterChance;

    [HideInInspector]public int staEmptyChance;
    [HideInInspector]public int staFoodChance;
    [HideInInspector]public int staPoacherCampChance;
    [HideInInspector]public int staPoacherChance;
    [HideInInspector]public int staWaterChance;

    // Use this for initialization
    void Start () {
        GenerateNextModule();
    }

    public void GenerateNextModule()
    {
        staEmptyChance = emptyChance;
        staFoodChance = staEmptyChance+foodChance;
        staPoacherCampChance = staFoodChance + poacherCampChance;
        staPoacherChance = staPoacherCampChance + poacherCampChance;
        staWaterChance = staPoacherChance + waterChance;
        
        if (moduleSetNumber == 1)
        {
            emptyModules = Resources.LoadAll<GameObject>("Modules/Set1/Empty") as GameObject[];
            foodModules = Resources.LoadAll<GameObject>("Modules/Set1/Food") as GameObject[];
            poacherCampModules = Resources.LoadAll<GameObject>("Modules/PoacherCamp/") as GameObject[];
            poacherModules = Resources.LoadAll<GameObject>("Modules/Set1/Poachers") as GameObject[];
            waterModules = Resources.LoadAll<GameObject>("Modules/Set1/Water") as GameObject[];
        }


        moduleCategory = Random.Range(1, emptyChance + foodChance + waterChance + poacherCampChance + poacherChance + waterChance);


        //choose type of module
        //empty module
        if (moduleCategory <= staEmptyChance)
        {
            Instantiate(emptyModules[Random.Range(0, emptyModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
        }
        //food module
        else if (moduleCategory > staEmptyChance && moduleCategory <= staFoodChance)
        {
            Instantiate(foodModules[Random.Range(0, foodModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
        }
        //poacher camp module
        else if (moduleCategory > staFoodChance && moduleCategory <= staPoacherCampChance)
        {
            Instantiate(poacherCampModules[Random.Range(0, poacherCampModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
        }
        //poacher module
        else if (moduleCategory > staPoacherCampChance && moduleCategory <= staPoacherChance)
        {
            Instantiate(poacherModules[Random.Range(0, poacherModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
        }
        //water module
        else if (moduleCategory > staPoacherChance && moduleCategory <= staWaterChance)
        {
            Instantiate(waterModules[Random.Range(0, waterModules.Length)], gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
