using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThisObjectAfterSomeTime : MonoBehaviour {
    public float time;
    public GameObject targetDestroy;
	// Use this for initialization
	void Start () {
        Destroy(targetDestroy, time);

    }

    // Update is called once per frame
    void Update () {
	}
}
