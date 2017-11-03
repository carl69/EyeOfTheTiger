using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHunterTarget02 : MonoBehaviour {

    public GameObject Target;
    public List<GameObject> Targets = new List<GameObject>();
    AiHunters02 aihunter02;


    float UpdateTimer = 2;
    float curTime = 2;

    private void Start()
    {
        aihunter02 = GetComponent<AiHunters02>();
    }
    private void Update()
    {
        if (Targets[0] == null)
        {
            Target = null;
            Targets.Remove(Targets[0]);
        }
        if (Targets.Count != 0 )
        {
            
            if (Targets[0] != null)
            {
                if (aihunter02.fpsTarget != Target.transform)
                {
                    aihunter02.fpsTarget = Target.transform;
                }
            }
            
        }
        
    }


    private void OnTriggerEnter(Collider x)
    {
        if ((x.tag == "Player" || x.tag == "Pray") && !Targets.Contains(x.gameObject) && x.transform.gameObject.layer != 11)
        {
            Targets.Add(x.gameObject);

            if (Target == null)
            {
                print("problem is here");
                Target = x.gameObject;
            }
            for (int i = 0; i < Targets.Count; i++)
            {
                if (Targets[i] == null)
                {
                    Targets.Remove(Targets[i]);
                }
                if (Targets[i].tag == "Player")
                {
                    Target = Targets[i];
                }
            }
            
        }
    }
    private void OnTriggerExit(Collider d)
    {
        if (d.tag == "Player" || d.tag == "Pray")
        {
            Targets.Remove(d.gameObject);


            if (d.tag == "Player")
            {
                if (Targets.Count <= 2)
                {
                    if (Target != Targets[Targets.Count - 1])
                    {
                        Target = Targets[Targets.Count - 1];
                    }
                    else
                    {
                        Target = Targets[Targets.Count - 2];
                    }
                }
            }

            Targets.Remove(d.gameObject);


        }
    }


}
