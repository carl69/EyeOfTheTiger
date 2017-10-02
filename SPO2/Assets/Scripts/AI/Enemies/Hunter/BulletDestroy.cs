using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {
    // Use this for initialization
    MamaTigerMovement TMove;
	void Start () {
        
        Destroy(this.gameObject, 3);
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Mother"))
        {
            TMove = other.GetComponent<MamaTigerMovement>();
            TMove.enabled = false;

            Destroy(this.gameObject);

        }
    }
}
