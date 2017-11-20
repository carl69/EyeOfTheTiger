using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPayingFoodToThisObject : MonoBehaviour
{
    public bool canGiveFood;
    public GameObject parentToSprites;
    public GameObject parentToGraySprite;
    public GameObject[] sprites;
    private int count;
    //********************Player food loss***********************************//
    private GameObject player;
    private food pfood;
    public float foodGivingRate;
    public float spentFood;
    public float totalCost;
    private float aCubeOfMeat = 10;
    private float timer;
    public bool Done = false;
    public GameObject ActivateScript;


    public bool notCanGetMoreCubsThenOne = false;
    private GameObject cub;
    bool FirstTimeStart = true;
    // Use this for initialization
    void Start()
    {
        ActivateScript.SetActive(false);
        timer = foodGivingRate;
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            pfood = player.GetComponent<food>();
        }

        count = 0;
        foreach (Transform i in parentToSprites.transform)
        {
            count++;
        }
        sprites = new GameObject[count];
        count = 0;
        foreach (Transform i in parentToSprites.transform)
        {
            sprites[count] = i.gameObject;
            count++;
        }


        for (int i = 0; i < sprites.Length; i++)
        {

            sprites[i].SetActive(false);

        }
        parentToGraySprite.SetActive(false);
        parentToSprites.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!cub && notCanGetMoreCubsThenOne)
        {
            cub = GameObject.FindGameObjectWithTag("Cub");
        }
        else if (notCanGetMoreCubsThenOne)
        {
            if (spentFood != 0)
            {
                parentToGraySprite.SetActive(false);
                parentToSprites.SetActive(false);

                for (int i = 0; i < sprites.Length; i++)
                {
                    sprites[i].SetActive(false);
                }

                pfood.eaten += spentFood;
                spentFood = 0;
            }
            return;
        }


        if (canGiveFood && Done == false)
        {
            if (parentToSprites.activeSelf == false)
            {
                parentToGraySprite.SetActive(true);
                parentToSprites.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                print("Button Works");


                if (spentFood == aCubeOfMeat * 3)
                {
                    Done = true;
                    PAY();
                    return;
                }
                else if (pfood.eaten >= 9)//aCubeOfMeat + 1)
                {
                    if (spentFood == aCubeOfMeat * 3)
                    {
                        Looks();
                    }

                    if (spentFood == aCubeOfMeat * 2)
                    {
                        Looks();
                    }

                    if (spentFood == aCubeOfMeat)
                    {
                        Looks();
                    }

                    if (spentFood == 0 && Done == false)
                    {
                        Looks();
                    }
                }
            }
            else if (timer < foodGivingRate)
            {
                //timer += 1 * Time.deltaTime;
                return;
            }
            else if (spentFood != 0)
            {
                for (int i = 0; i < sprites.Length; i++)
                {

                    sprites[i].SetActive(false);

                }

                pfood.eaten += spentFood;
                spentFood = 0;
            }
        }
        else if (spentFood != 0)
        {
            for (int i = 0; i < sprites.Length; i++)
            {

                sprites[i].SetActive(false);

            }

            pfood.eaten += spentFood;
            spentFood = 0;
        }
    }
    void SummonImage()
    {

        for (int i = 1; i < sprites.Length + 1; i++)
        {
            if (spentFood == aCubeOfMeat * i)
            {
                sprites[i - 1].SetActive(true);
            }
        }

        if (spentFood >= totalCost)
        {
            PAY();
        }
    }
    void Looks()
    {
        pfood.eaten -= aCubeOfMeat;
        spentFood += aCubeOfMeat;
        timer = 0;


        SummonImage();
    }
    public void PAY()
    {
        ActivateScript.SetActive(true);
        parentToGraySprite.SetActive(false);
        Done = true;
        spentFood = 0;
        for (int i = 0; i < sprites.Length; i++)
        {

            sprites[i].SetActive(false);

        }
        //Destroy(this);
        this.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            pfood = player.GetComponent<food>();
        }

        if (other.tag == "Player")
        {
            if (Done == false)
            {
                timer = 0;

                canGiveFood = true;
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            parentToGraySprite.SetActive(false);
            parentToSprites.SetActive(false);
            canGiveFood = false;
        }
    }
    private void OnEnable()
    {
        if (Done == false && FirstTimeStart == false)
        {
            canGiveFood = false;
            Invoke("resets", 1f);

        }
        else
        {
            FirstTimeStart = false;
        }
    }
    void resets()
    {
        parentToGraySprite.SetActive(true);
        parentToSprites.SetActive(true);

        timer = 0;

        canGiveFood = true;
    }

}