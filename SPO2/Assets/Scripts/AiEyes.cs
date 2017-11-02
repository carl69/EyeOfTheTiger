using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEyes : MonoBehaviour
{
    public GameObject test;


    public float maxEyeSight = 25;
    public LayerMask LayersThatCanBeSeen;

    public RaycastHit[] hits;

    private void FixedUpdate()
    {
        Ray eyes = new Ray(transform.position, test.transform.position);
        Debug.DrawLine(transform.position, test.transform.position , Color.green);

        hits = Physics.RaycastAll(eyes, maxEyeSight, LayersThatCanBeSeen);

        
            //Debug.Log(hits[0].transform.gameObject);

        

        //foreach(RaycastHit hit in hits)
        //{
        //    Debug.DrawLine(hit.point, hit.point + Vector3.up * 5, Color.red);
        //}
    }
}

