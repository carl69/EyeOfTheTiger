using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHunterTarget02 : MonoBehaviour {

    public GameObject Target;
    public List<GameObject> Targets = new List<GameObject>();
    AiHunters02 aihunter02;
    public GameObject Alert;

    public AudioSource AlertSource;
    public AudioClip AlertClip;

    float UpdateTimer = 2;
    float curTime = 2;

    private void Start()
    {
        aihunter02 = GetComponent<AiHunters02>();

        AlertSource = gameObject.GetComponent<AudioSource>();

    }
    private void Update()
    {
        if (Target != null)
        {
            if (Target.layer != 14)
            {
                if (Alert.activeInHierarchy == false)
                {
                    Alert.SetActive(true);
                    Debug.Log("Hunter is alert!");
                    if (!AlertSource.isPlaying)
                    {
                        AlertSource.PlayOneShot(AlertClip, 1f);
                    }

                }
            }
            else if (Target.layer == 14 && Alert.activeInHierarchy == true)
            {
                aihunter02.fpsTarget = null;
                Alert.SetActive(false);
            }
        }
        else if(Alert.activeInHierarchy == true)
        {
            aihunter02.aihunterShooting.enabled = false;
            aihunter02.fpsTarget = null;
            Alert.SetActive(false);
        }

        //if (Targets[0] == null || Target.layer == 14)
        //{
        //    Target = null;
        //    Targets.Remove(Targets[0]);
        //    aihunter02.fpsTarget = null;
        //}
       
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
        if ((x.tag == "Player" || x.tag == "Pray") && !Targets.Contains(x.gameObject))
        {
            if (x.transform.gameObject.layer != 14)
            {
                Targets.Add(x.gameObject);
                
                if (Target == null)
                {
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
    }
    private void OnTriggerExit(Collider d)
    {
        if (d.tag == "Player" || d.tag == "Pray")
        {
            Targets.Remove(d.gameObject);

            if (d.gameObject == aihunter02.fpsTarget)
            {
                aihunter02.fpsTarget = null;
                Target = null;
            }
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
