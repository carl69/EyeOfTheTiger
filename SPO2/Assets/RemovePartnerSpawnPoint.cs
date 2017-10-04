using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePartnerSpawnPoint : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WallofDeath")
        {
            Destroy(this.gameObject);
        }
    }
}
