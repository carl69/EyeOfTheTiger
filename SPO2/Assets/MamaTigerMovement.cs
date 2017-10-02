using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaTigerMovement : MonoBehaviour {
    //Stats
    public float walkingSpeed;
    public float RunningSpeed;
    public float jumpVelocity;
    Rigidbody myBody;

    public int stage = 0;
        public Transform[] targetPoint;
    //What to do to trigger the next stage
        public string Naming = "Delay, AD, Wait, Jump, Walk, Run";
        public string[] Commando;
    //What To Do to go to next stage
        public string ToDo = "AD, ColideWithMother, Distance, Drinking, Eating";
        public string[] nextStage;

        public float[] delayTime;
        public float[] Distance;
        public GameObject[] Targets;

    //checks if you written it right
        //private string[] allStringsInToDo = { "AD", "ColideWithMother", "Distance", "Drinking", "Eating"};
        //private string[] allStringsInNaming = { "Delay", "AD", "Wait", "Jump", "Walk", "Run"};
    //Used in the Delay Funcion
    private float startTime;
    private bool changed = true;
    //Used in the AD Funcion
    private Transform curTarget;
    //Used in the Wait Funcion
    private bool closeToMom = false;

    //Finds The Player && Codes
    GameObject player;
    food pFood;
    PlayerWater pWater;
    private void Start()
    {
        player = GameObject.Find("Player");
        pFood = player.GetComponent<food>();
        pWater = player.GetComponent<PlayerWater>();

        ToDo = "AD, ColideWithMother, Distance, Drinking, Eating";
        Naming = "Delay, AD, Wait, Jump, Walk, Run";

    curTarget = targetPoint[stage];
        myBody = GameObject.FindGameObjectWithTag("Mother").GetComponent<Rigidbody>();
    }

    void Update () {

        //NextStep
        if (nextStage[stage] == "AD")
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                NextStage();
            }
        }

        if (nextStage[stage] == "ColideWithMother")
        {
                float dist = Vector3.Distance(targetPoint[stage].position, transform.position);
            if (dist <= 0.5f && closeToMom)
            {
                NextStage();
            }
        }

        if (nextStage[stage] == "Distance")
        {

            if (Targets[stage] == null)
            {
                Debug.Log("No Target On Stage " + stage);
            }
            else
            if (Distance[stage] == 0)
            {
                Debug.Log("Distance on Stage " + stage + " are not applied");
            }
            else {
                float dist = Vector3.Distance(Targets[stage].transform.position, transform.position);
                if (dist <= Distance[stage])
                {
                    NextStage();
                }
            }
        }

        if (nextStage[stage] == "Drinking")
        {
            if (pWater.drinkAudio)
            {
                NextStage();
            }

        }

        if (nextStage[stage] == "Eating")
        {

        }




        //Select Funcions
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
            WalkTo();
        }
        if (Commando[stage] == "Run")
        {
            RunPoint();
        }


    }
    //Mods
    void Jump() {

        Transform walkToTarget = targetPoint[stage];
        float step = walkingSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, walkToTarget.position, step);
        float dist = Vector3.Distance(walkToTarget.position, transform.position);
        if (dist <= 0.5f)
        {
            myBody.AddForce(transform.up * jumpVelocity * Time.deltaTime);
            NextStage();
        }

        

    }
    void WalkTo() {
            Transform walkToTarget = targetPoint[stage];
            float step = walkingSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, walkToTarget.position, step);
            float dist = Vector3.Distance(walkToTarget.position, transform.position);
        if (dist <= 0.5f)
        {
            NextStage();
        }

    }
    void Wait() {
            Transform endTarget = targetPoint[stage];
            float dist = Vector3.Distance(endTarget.position, transform.position);
            float step = walkingSpeed * Time.deltaTime;

        if (dist >= 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endTarget.position, step);
        }
        
    }
    void RunPoint() {
            Transform walkToTarget = targetPoint[stage];
            float step = (walkingSpeed + RunningSpeed) * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, walkToTarget.position, step);
            float dist = Vector3.Distance(walkToTarget.position, transform.position);
        if (dist <= 0.5f)
        {
            NextStage();
        }
    }
    void WalkBackAndForth() {
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
            startTime = delayTime[stage] + Time.time;
            changed = false;
        }else if (startTime <= Time.time)
        {
            changed = true;
            NextStage();
        }

    }
    void Carry() {

    }
    void LetDown() {

    }
    //Move To Next Stage
    void NextStage() {
        stage += 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            closeToMom = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            closeToMom = false;
        }
    }
}
