using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenAreas : MonoBehaviour
{
    public bool IsPlayerHere;
    public Material visibleMat;
    public Material hiddenMat;

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsPlayerHere = true;
            GetComponent<Renderer>().material = visibleMat;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsPlayerHere = false;
            GetComponent< Renderer > ().material = hiddenMat;
        }
    }
    /*public bool IsPlayerHere;
    public Material[] materials;
    public float changeInterval = 0.33F;
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void Update()
    {
        if (materials.Length == 0)
            return;

        // we want this material index now
        int index = Mathf.FloorToInt(Time.time / changeInterval);

        // take a modulo with materials count so that animation repeats
        index = index % materials.Length;

        // assign it to the renderer
        rend.sharedMaterial = materials[index];
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            IsPlayerHere = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsPlayerHere = false;
        }
    }*/
}
