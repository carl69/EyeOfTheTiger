using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerPartnerSpawner : MonoBehaviour {
    public GameObject Partner;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!GameObject.FindGameObjectWithTag("Partner") && !GameObject.FindGameObjectWithTag("Cub"))
            {
                SpawnPartner();
            }
        }
    }
    void SpawnPartner() {
        int SpawnPoint = Random.Range(0, transform.childCount);
        GameObject partnerSpawner = this.gameObject.transform.GetChild(SpawnPoint).gameObject;
        Instantiate(Partner, new Vector3(partnerSpawner.transform.position.x, partnerSpawner.transform.position.y, 0), Quaternion.identity);
    }
}
