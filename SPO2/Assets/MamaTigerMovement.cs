using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaTigerMovement : MonoBehaviour {
    //Affects the object
    [Header("Script usage")]
    [Tooltip("Whats the time since object start")]
    public float clock;
    [Tooltip("Current elements index active")]
    public int stage = 0;
    //Stats
    [Header("Stats of the Object")]
    [Tooltip("Can the object collide with the player?")]
    public bool collideWithPlayer;
    [Tooltip("How fast the object walks")]
    public float walkingSpeed;
    [Tooltip("How fast the object runs (Running = WalkingSpeed + RunningSpeed)")]
    public float RunningSpeed;
    [Tooltip("How high the object jumps")]
    public float jumpVelocity;
    Rigidbody myBody;

    [Header("Stages")]

    [Tooltip("Commands you can put in on the Commant list")]
    public string[] allStringsInCommando = { "Delay", "Patrol", "Wait", "Jump", "Walk", "Run", "Carry", "LetGo", "RunFromTarget", "GoToStage", "DestroyTarget" };
    //ComandoList

    //  Delay, 
    //  AD / Patrol, 
    //  Wait, 
    //  Jump, 
    //  Walk, 
    //  Run, 
    //  Carry, 
    //  LetGo, 
    //  RunfromTarget,
    //  GoToStage.
    [Tooltip("What the Object do")]
    public string[] Commando;

    [Tooltip("Commands you can put in on the Next Stage list")]
    public string[] allStringsInNextStage = { "Timed", "Clock", "AD", "ColideWithMother", "Distance", "Drinking", "Eating", "TargetDestroyed" };
    //NextStageList

    //  Timed,
    //  Clock,
    //  AD,
    //  ColideWithMother,
    //  Distance,
    //  Drinking,
    //  Eating,
    //  TargetDestroyed.
    [Tooltip("What needs to happen for the object to select the next element")]
    public string[] nextStage;

    [Header("Connditions needed to be meet depending on the code")]
    [Tooltip("Waypoints you can drag in. Needed in: Walk, Run, Jump, ColideWithMother")]
    public Transform[] targetPoint;
    public bool semiRandomTurnPoints;
    public float howRandom;

    [Tooltip("The time until the object skips to the next element. Needed in: Timed")]
    public float[] delayTime;
    [Tooltip("The Distance to *Targets*. Needed in: Distance")]
    public float[] Distance;
    [Tooltip("Targets turn into the object with name *Player*")]
    public bool[] TargetBecomesPlayer;
    [Tooltip("The object watches the current target. Needed in: Distance, TargetDestroyed, Carry, RunfromTarget")]
    public GameObject[] Targets;
    [Tooltip("The time since the object got created. Needed in: Clock")]
    public float[] timeOfDay;
    [Tooltip("Go To a selected stage in the element stage. Needed in: GoToStage")]
    public int[] GoToStage; 


    //Used in the Delay Funcion
    private float startTime;
    private bool changed = true;
    //Used in the AD Funcion
    private Transform curTarget;
    private float distanceForRandom = 0;
    //Used in the Wait Funcion
    public float waitingDis;
    private bool closeToMom = false;

    //Finds The Player && Codes
    private bool carriCub = false;
    GameObject CubHolder;
    GameObject player;
    food pFood;
    PlayerWater pWater;
    Movement pMovement;
    float startTimeCheck;


    private void Start()
    {
        startTimeCheck = Time.time;

        if (!collideWithPlayer)
        {
            gameObject.layer = 11;
        }

        CubHolder = GameObject.Find("CubHolder");
        player = GameObject.Find("Player");
        if (player != null)
        {
            pMovement = player.GetComponent<Movement>();
            pFood = player.GetComponent<food>();
            pWater = player.GetComponent<PlayerWater>();
        }
        

       // Naming = "Delay, AD, Wait, Jump, Walk, Run";

        curTarget = targetPoint[stage];
        myBody = this.gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        clock = Time.time - startTimeCheck;
        // basic mods that need constant update
        if (carriCub)
        {
            player.transform.position = CubHolder.transform.position;
        }

        if (TargetBecomesPlayer[stage])
        {
            if (Targets[stage] == null)
            {
                Targets[stage] = GameObject.Find("Player");
            }
        }
    }
    void FixedUpdate () {


        //NextStep
        if (nextStage[stage] == "Timed")
        {
            Waiting();
        }
        if (nextStage[stage] == "Clock")
        {
            Clock();
        }

        if (nextStage[stage] == "AD")
        {
            ADpressed();
        }

        if (nextStage[stage] == "ColideWithMother")
        {
            MotherColiding();
        }

        if (nextStage[stage] == "Distance")
        {
            DistanceFunch();           
        }

        if (nextStage[stage] == "Drinking")
        {
            PlayerDrinking();
        }

        if (nextStage[stage] == "Eating")
        {
            PlayerEating();
        }

        if (nextStage[stage] == "TargetDestroyed")
        {
            DestroyTarget();
        }


        //Select Funcions
        if (Commando[stage] == "DestroyTarget")
        {
            DestroyTargets();
        }
        if (Commando[stage] == "Delay")
        {
            waitforsomesec();
        }
        if (Commando[stage] == "AD" || Commando[stage] == "Patrol")
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
        if (Commando[stage] == "Carry")
        {
            Carry();
        }
        if (Commando[stage] == "LetGo")
        {
            LetDown();
        }
        if (Commando[stage] == "RunFromTarget")
        {
            RunAway();
        }
        if (Commando[stage] == "GoToStage")
        {
            ToStageZero();
        }
    }
    //ToDos
    void Clock() {
        if (timeOfDay[stage] < clock)
        {
            NextStage();
        }
    }
    void ADpressed() {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextStage();
        }
    }
    void MotherColiding()
    {

        float dist = Vector3.Distance(targetPoint[stage].position, transform.position);
        if (dist <= 0.5f && closeToMom)
        {
            if (!collideWithPlayer)
            {
                gameObject.layer = 11;
            }
            NextStage();
        }
        else if (gameObject.layer == 11)
        {
            gameObject.layer = 15;
        }
    }
    void DistanceFunch() {
        if (Targets[stage] == null)
        {
            Debug.Log("No Target On Stage " + stage);
        }
        else
            if (Distance[stage] == 0)
        {
            Debug.Log("Distance on Stage " + stage + " are not applied");
        }
        else
        {
            float dist = Vector3.Distance(Targets[stage].transform.position, transform.position);
            if (dist <= Distance[stage])
            {
                NextStage();
            }
        }
    }
    void PlayerDrinking() {
        if (pWater.drinkAudio)
        {
            NextStage();
        }
    }
    void PlayerEating() {
        if (pFood.eating)
        {
            NextStage();
        }
    }
    void DestroyTarget() {
        if (Targets[stage] == null)
        {
            NextStage();
        }
    }
    void Waiting() {
        if (changed)
        {
            startTime = delayTime[stage] + Time.time;
            changed = false;
        }
        else if (startTime <= Time.time)
        {
            changed = true;
            NextStage();
        }
    }

    //Commands
    void DestroyTargets() {
        Destroy(Targets[stage].gameObject);
    }
    void Jump() {

        Transform walkToTarget = targetPoint[stage];
        float step = walkingSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, walkToTarget.position, step);
        float dist = Vector3.Distance(walkToTarget.position, transform.position);
        if (dist <= 0.5f)
        {
            NextStage();
            myBody.AddForce(transform.up * jumpVelocity * Time.deltaTime);
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

        if (dist >= waitingDis)
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
        if (semiRandomTurnPoints)
        {
            if (dist <= 0.5f + distanceForRandom)
            {
                //Find The Next Target
                if (curTarget == target0)
                {
                    distanceForRandom = Random.Range(0, howRandom);
                    curTarget = target1;
                }
                else if (curTarget == target1)
                {
                    distanceForRandom = Random.Range(0, howRandom);
                    curTarget = target0;
                }

            }
        }
        else {
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
        if (!collideWithPlayer)
        {
            gameObject.layer = 15;
        }
        Transform walkToTarget = Targets[stage].transform;
            float step = walkingSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, walkToTarget.position, step);
        if (closeToMom)
        {
            carriCub = true;
            pMovement.enabled = false;
            if (!collideWithPlayer)
            {
                gameObject.layer = 11;

            }
            NextStage();
        }
    }
    void LetDown() {
            Transform walkToTarget = targetPoint[stage];
            float step = walkingSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, walkToTarget.position, step);
            float dist = Vector3.Distance(walkToTarget.position, transform.position);
        if (dist <= 0.5f)
        {
            carriCub = false;
            pMovement.enabled = true;
            NextStage();
        }
    }
    void RunAway() {
            Transform walkToTarget = Targets[stage].transform;
            float step = (walkingSpeed + RunningSpeed) * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, walkToTarget.position, -step);
    }
    void ToStageZero() {
        stage = GoToStage[stage];
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
