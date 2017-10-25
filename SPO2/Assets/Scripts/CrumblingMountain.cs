using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingMountain : MonoBehaviour {
    public float deathTimer = 10f;
    public bool isBeingDestroyed=false;
    public GameObject particles;
    Animator anim;
    // Use this for initialization
    void Start () {
        isBeingDestroyed = false;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "WallofDeath")
        {
            isBeingDestroyed = true;
            print("crumble,crumble");
        }
    }

    // Update is called once per frame
    void Update () {
        if (isBeingDestroyed == true)
        {
            particles.active = true;
            anim.SetBool("IsCrumbling", isBeingDestroyed);
            Destroy(gameObject, deathTimer);
        }
    }
}
