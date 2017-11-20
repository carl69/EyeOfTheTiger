using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubLevel02MovementScript : MonoBehaviour {
    public float Running;
    public float Walking;
    public float[] MinSleepTime, MaxSleepTime;
    public float[] MinIdleTime, MaxIdleTime;

    public Vector2 RandomWonderPoint;
    public GameObject Home;
    public float distanceTooWonderPoint;

    public enum State
    {
        RunningToPoint, idle, WalkingToPoint, sleeping
    }
    public State GoTo;

    public float maxDistanceFromHive;
    public int LeftRight;
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
        //Running to the point
        transform.position = new Vector2(this.transform.position.x + (Walking * LeftRight * Time.deltaTime), transform.position.y);

        //Ending the state
        if (distanceTooWonderPoint < 2)
        {
            ReachPoint();
        }
    }
    void StayAtPoint() { }
    void Sleeping() { }

    void ReachPoint() {
        float Xposition = Random.Range(-maxDistanceFromHive, maxDistanceFromHive);

        RandomWonderPoint = new Vector2(Home.transform.position.x + Xposition, this.transform.position.y);
    }
}
