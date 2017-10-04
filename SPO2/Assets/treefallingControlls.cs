using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treefallingControlls : MonoBehaviour {

    public Animator anim;
    // Use this for initialization
    void Start()
    {
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            anim.enabled = true;

        }
        if (Input.GetKey(KeyCode.B))
        {
            
        }
    }
}
