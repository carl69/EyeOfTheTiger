using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILookAt : MonoBehaviour
{
    public float eyesight = 25;
    public GameObject Target;
    public GameObject Hunter;

    Vector3 start;

    //neededstuff
    HunterMovement HunterMovement;
    void hunting()
    {
        if (HunterMovement.Target != Target)
        {
            HunterMovement.Target = Target;
        }

        float dist = Vector3.Distance(Target.transform.position, Hunter.transform.position);
        //print("Distance to other: " + dist);
        if (dist < eyesight)
        {
            transform.position = Target.transform.position;
        }
        else
        {
            if (Target != null)
            {
                HunterMovement.Target.transform.position = Target.transform.position;
                Target = null;
            }
            
        }
    }

    void sleeping() { }
    void exploring() {
        //this.transform.position = new Vector3 (transform.position.x, transform.position.y, start.z);
    }
    private void Start()
    {
        start = this.transform.position;

        HunterMovement = Hunter.GetComponent<HunterMovement>();
    }
    private void Update()
    {
        if (Target != null)
        {
            hunting();
            Debug.Log("hunting");
        }
        else
        {
            exploring();
            Debug.Log("exploring");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
       
            if (other.tag == "Player")
            {
                Target = other.gameObject;
            }
            if (other.tag == "Pary")
            {
                Target = other.gameObject;
            }
        
    }
}
