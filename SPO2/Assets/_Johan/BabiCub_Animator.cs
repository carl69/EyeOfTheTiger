using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabiCub_Animator : MonoBehaviour {
    public GameObject cub;
    public float velocity;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = cub.GetComponent<MamaTigerMovement>().vel;

        anim.SetFloat("Velocity", velocity);

        if (velocity < -0.5f)
            transform.forward = new Vector3(-1f, 0f, 0f);
        else if (velocity > 0.5f)
            transform.forward = new Vector3(1f, 0f, 0f);
    }
}
