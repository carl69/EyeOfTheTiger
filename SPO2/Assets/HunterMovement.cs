using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMovement : MonoBehaviour {
    public GameObject Target;
    public float shootRange;
    public float movementSpeed = 100;
    public int HuntingMove;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Target != null)
        {
            Hunting();

            if (Target.transform.position.x > transform.position.x)
            {
                HuntingMove = 1;
            }
            else if (Target.transform.position.x < transform.position.x)
            {
                HuntingMove = -1;
            }
        }
        else
        {
            HuntingMove = 0;
        }
	}

    void Hunting()
    {
        float dist = Vector3.Distance(Target.transform.position, transform.position);
        if (dist > shootRange && HuntingMove != 0)
        {
            rb.AddForce((transform.right * movementSpeed * HuntingMove) * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
