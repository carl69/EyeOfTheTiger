using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEyes : MonoBehaviour
{
    public GameObject test;


    public float maxEyeSight = 25;
    public LayerMask LayersThatCanBeSeen;

    public RaycastHit[] hits;

    public GameObject hunter;
    AiHunterTarget02 aiHunterTarget02;
    Ray eyes;
    private void Start()
    {
        aiHunterTarget02 = hunter.GetComponent<AiHunterTarget02>();
    }
    private void FixedUpdate()
    {
        //transform.rotation = Quaternion.Euler(0, transform.parent.transform.rotation.y - 90,0); //transform.parent.transform.rotation;
        //print(transform.parent.transform.rotation.y);
        if (transform.parent.transform.rotation.y < 0)
        {
            eyes = new Ray(transform.position, Vector3.left);

        }
        else
        {
            eyes = new Ray(transform.position, Vector3.right);

        }
        Debug.DrawLine(transform.position, test.transform.position , Color.green);

        hits = Physics.RaycastAll(eyes, maxEyeSight, LayersThatCanBeSeen);


        //Debug.Log(hits[0].transform.gameObject);


        if (hits.Length <= 0)
        {
            aiHunterTarget02.Target = null;
            aiHunterTarget02.Targets.Clear();
            return;
        }

        foreach (RaycastHit hit in hits)
        {
            if (!aiHunterTarget02.Targets.Contains(hit.transform.gameObject))
            {
                aiHunterTarget02.Targets.Add(hit.transform.gameObject);
            }
            


            if (hit.transform.gameObject.layer == 8)
            {

                aiHunterTarget02.Target = hit.transform.gameObject;
                Debug.DrawLine(hit.point, hit.point + Vector3.up * 5, Color.red);
            }
            else if (hit.transform.gameObject.layer == 13)
            {
                aiHunterTarget02.Target = hit.transform.gameObject;
            }

        }
    }
}

