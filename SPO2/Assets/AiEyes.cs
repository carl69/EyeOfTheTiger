using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEyes : MonoBehaviour
{
    public float maxEyeSight = 25;
    public LayerMask LayersThatCanBeSeen;

    private void FixedUpdate()
    {
        Ray eyes = new Ray(transform.position, Vector3.forward);
        RaycastHit[] hits = Physics.RaycastAll(eyes, maxEyeSight, LayersThatCanBeSeen);

        Debug.DrawLine(transform.position, transform.position + Vector3.forward * maxEyeSight, Color.green);

        foreach(RaycastHit hit in hits)
        {
            Debug.DrawLine(hit.point, hit.point + Vector3.up * 5, Color.red);
        }
    }
}

