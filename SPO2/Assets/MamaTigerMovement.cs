using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaTigerMovement : MonoBehaviour {
        public int stage = 0;
        public Transform[] targetPoint;
        public int[] whatTODo;
        public float walkingSpeed;

    //What to do to trigger the next stage
        public string Naming = "Delay, AD, Wait, Jump, Walk,Run";

        public string[] Commando;
        public float[] delayTime;
       
    //**************************//

    //Used in the Delay Funcion
        private float startTime;
        private bool changed = true;
    //Used in the AD Funcion
        private Transform curTarget;
    //**************************//

    private void Start()
    {
        curTarget = targetPoint[stage];
    }

    void Update () {
        if (Commando[stage] == "Delay")
        {
            waitforsomesec();
        }
        if (Commando[stage] == "AD")
        {
            WalkBackAndForth();
        }
        if (Commando[stage] == "Wait")
        {
            Wait();
        }
        if (Commando[stage] == "Jump")
        {
            Jump();
        }
        if (Commando[stage] == "Walk")
        {
            WalkfromPoints();
        }
        if (Commando[stage] == "Run")
        {
            RunPoint();
        }


    }
    void Jump() {

    }
    void WalkfromPoints() {

    }
    void Wait() {

    }
    void RunPoint() {

    }
    void WalkBackAndForth() {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextStage();
        }

        //Sets Walking Points
            Transform target0 = targetPoint[stage];
            Transform target1 = targetPoint[stage+1];
        //Update the points
        if (curTarget == target0 || curTarget == target1)
        {
        }
        else
        {
            curTarget = target0;
        }
        //Calulate the distance to the next target
        float dist = Vector3.Distance(curTarget.position, transform.position);
        if (dist <= 0.5f)
        {
            //Find The Next Target
            if (curTarget == target0)
            {
                curTarget = target1;
            }
            else if (curTarget == target1)
            {
                curTarget = target0;
            }

        }
        //MovesThere
        float step = walkingSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, curTarget.position, step);
    }
    void waitforsomesec(){
        
        if (changed)
        {
            Debug.Log("");
            startTime = delayTime[stage] + Time.time;
            changed = false;
        }else if (startTime <= Time.time)
        {
            Debug.Log(Time.time);
            changed = true;
            NextStage();
        }

    }
    void NextStage() {
        stage += 1;
    }
}
