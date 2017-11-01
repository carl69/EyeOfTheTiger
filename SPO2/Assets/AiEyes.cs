using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEyes : MonoBehaviour
{
    public GameObject test;


    public float maxEyeSight = 25;
    public LayerMask LayersThatCanBeSeen;

    private void FixedUpdate()
    {
        Ray eyes = new Ray(transform.position, test.transform.position/*new Vector3(0,transform.rotation.y / 360,1)*/);
        RaycastHit[] hits = Physics.RaycastAll(eyes, maxEyeSight, LayersThatCanBeSeen);


        //Debug.Log(hits[0].transform.gameObject);
        Debug.DrawLine(transform.position, test.transform.position/*transform.position + (Vector3.forward * maxEyeSight)*/ , Color.green);

        foreach(RaycastHit hit in hits)
        {
            Debug.DrawLine(hit.point, hit.point + Vector3.up * 5, Color.red);
        }
    }
}

