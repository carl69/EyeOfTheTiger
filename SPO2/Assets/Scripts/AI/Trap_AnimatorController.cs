using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_AnimatorController : MonoBehaviour {
    public bool isTriggered = false;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        isTriggered = false;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTriggered = true;
            print("crumble,crumble");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered == true)
        {
            anim.SetBool("IsTriggered", isTriggered);
        }
    }
}
