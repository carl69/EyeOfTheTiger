using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubWaterUI : MonoBehaviour
{

    public float MaxThirst;
    public float CurThirst;

    CubLife cublife;
    // Use this for initialization
    void Start()
    {
        cublife = GameObject.Find("Cub").GetComponent<CubLife>();
    }

    // Update is called once per frame
    void Update()
    {
        MaxThirst = cublife.maxThirst;
        CurThirst = cublife.curThirst;

        transform.localScale = new Vector3(CurThirst / MaxThirst, 1, 0);
    }
}

