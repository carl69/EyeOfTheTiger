using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubHungerUI : MonoBehaviour
{

    public float MaxHunger;
    public float CurHunger;

    CubLife cublife;
    // Use this for initialization
    void Start()
    {
        cublife = GameObject.Find("Cub").GetComponent<CubLife>();
    }

    // Update is called once per frame
    void Update()
    {
        MaxHunger = cublife.maxHunger;
        CurHunger = cublife.curHunger;

        transform.localScale = new Vector3(CurHunger / MaxHunger, 1, 0);
    }
}

