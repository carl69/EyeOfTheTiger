using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHunterIdel : MonoBehaviour {
    public enum State
    {
        patrolling, idle, walk_around, sleeping
    }
    public State GoTo;

    [Header("Just Stats")]
    Rigidbody rb;
    [Range(0.001f, 20f)]
    public float movementsSpeed;
    [Range(1f, 10f)]
    public float patrollingTurnSpeed;

    [Header("For Patrolling")]
    public Transform[] patrollPoints;
    Transform PatrollingTarget;
    [Range(1f, 10f)]
    public float newPatrollingTargetRange = 1;



    void Start () {
        rb = GetComponent<Rigidbody>();
        if (GoTo == State.patrolling)
        {
            PatrollingTarget = patrollPoints[Random.Range(0, patrollPoints.Length)];
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GoTo == State.patrolling)
        {
            float dist = Vector3.Distance(PatrollingTarget.position, transform.position);
            if (dist < newPatrollingTargetRange)
            {
                PatrollingTarget = patrollPoints[Random.Range(0, patrollPoints.Length)];
            }
            Quaternion rotation = Quaternion.LookRotation(PatrollingTarget.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * patrollingTurnSpeed);
            transform.position += (transform.forward * movementsSpeed * Time.deltaTime);
        }
	}
}
