using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public bool isMoving = false;
    Vector3 target;
    public float speed;
    // Use this for initialization
    void Start()
    {
        speed = 10f;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray02 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit02;
            if (Physics.Raycast(ray02, out hit02))
            {
                target = hit02.transform.position;
                Debug.Log(target);
               
                
            }
        }
    }
}
