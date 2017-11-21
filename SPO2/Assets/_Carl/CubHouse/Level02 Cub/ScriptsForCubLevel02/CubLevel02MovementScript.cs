using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubLevel02MovementScript : MonoBehaviour {
    //[Header("Stats of the Object")]
    //[Tooltip("Can the object collide with the player?")]
    [Header("Stats")]
    [Tooltip("Speed")]
    public float Running;
    [Tooltip("Speed")]
    public float Walking;
    //
    [Header("Sleeping")]
    [Tooltip("Time")]
    public float MinSleepTime;
    [Tooltip("Time")]
    public float MaxSleepTime;
    float SleepingTimer;
    //
    [Header("Idle")]
    [Tooltip("Time")]
    public float MinIdleTime;
    [Tooltip("Time")]
    public float MaxIdleTime;
    float IdleTimer;
    //
    public Vector2 RandomWonderPoint;
    public GameObject Home;
    public float distanceTooWonderPoint;
    //
    public enum State
    {
        RunningToPoint, idle, WalkingToPoint, sleeping
    }
    [Header("State")]
    public State GoTo;

    public float maxDistanceFromHive;
    int LeftRight;
    float Timerfloat;
    int RandomStateInt;
    // Use this for initialization
    void Start () {
        Home = GameObject.FindGameObjectWithTag("TigersDen");
        ReachPoint();
	}
	
	// Update is called once per frame
	void Update () {
        if (GoTo == State.RunningToPoint)
        {
            RunToPoint();
        }else if (GoTo == State.idle)
        {
            StayAtPoint();
        }else if (GoTo == State.WalkingToPoint)
        {
            WalkToPoint();
        }else if (GoTo == State.sleeping)
        {
            Sleeping();
        }

        distanceTooWonderPoint = Vector2.Distance(this.transform.position, RandomWonderPoint);
        if (this.transform.position.x > RandomWonderPoint.x)
        {
            LeftRight = -1;
        }
        else
        {
            LeftRight = 1;
        }
    }

    void RunToPoint() {

        //Running to the point
        transform.position = new Vector2(this.transform.position.x + (Running * LeftRight * Time.deltaTime), transform.position.y);

        //Ending the state
        if (distanceTooWonderPoint < 2)
        {
            ReachPoint();
        }
    }

    void WalkToPoint() {
        //Walking to the point
        transform.position = new Vector2(this.transform.position.x + (Walking * LeftRight * Time.deltaTime), transform.position.y);

        //Ending the state
        if (distanceTooWonderPoint < 2)
        {
            ReachPoint();
        }
    }

    void StayAtPoint() {
         
        if (Timerfloat > IdleTimer)
        {
            //ending the state
            Timerfloat = 0;
            ReachPoint();
        }
        else
        {
            Timerfloat += 1 * Time.deltaTime;
        }
    }

    void Sleeping() {
        //Finding the Bed
        RandomWonderPoint = Home.transform.position;


        //Ending the state
        if (distanceTooWonderPoint < 2)
        {
            //Start The Sleep
            if (Timerfloat > SleepingTimer)
            {
                //ending the state
                Timerfloat = 0;
                ReachPoint();
            }
            else
            {
                Timerfloat += 1 * Time.deltaTime;
            }
        }
        else
        {
            // walking to bed
            transform.position = new Vector2(this.transform.position.x + (Walking * LeftRight * Time.deltaTime), transform.position.y);
        }



    }

    void ReachPoint() {

        RandomState();
        float Xposition = Random.Range(-maxDistanceFromHive, maxDistanceFromHive);

        IdleTimer = Random.Range(MinIdleTime, MaxIdleTime);
        SleepingTimer = Random.Range(MinSleepTime, MaxSleepTime);
        RandomWonderPoint = new Vector2(Home.transform.position.x + Xposition, this.transform.position.y);
    }
    void RandomState()
    {
        RandomStateInt = Random.Range(0, 4);
        if (RandomStateInt == 0)
        {
            GoTo = State.RunningToPoint;
        }
        else if (RandomStateInt == 1)
        {
            GoTo = State.WalkingToPoint;
        }
        else if (RandomStateInt == 2)
        {
            GoTo = State.idle;
        }
        else if (RandomStateInt == 3)
        {
            int lessSleep = Random.Range(0,10);
            if (lessSleep == 0)
            {
                GoTo = State.sleeping;
            }
            else
            {
                RandomState();
            }
        }

    }
}
