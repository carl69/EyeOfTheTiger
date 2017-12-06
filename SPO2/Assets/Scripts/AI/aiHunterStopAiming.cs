using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiHunterStopAiming : MonoBehaviour {
    public bool TigerIsHere = false;

    void OnTriggerEnter(Collider O) {
        if (O.tag == "Player")
        {
            TigerIsHere = true;
        }
        
    }
    void OnTriggerExit(Collider O)
    {
        if (O.tag == "Player")
        {
            TigerIsHere = false;
        }
    }

}
