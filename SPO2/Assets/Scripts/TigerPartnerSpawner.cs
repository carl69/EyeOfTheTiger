using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerPartnerSpawner : MonoBehaviour {
    public GameObject Partner;
    public bool SpawnTigerPartner = false;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (SpawnTigerPartner)
        {
            if (!GameObject.FindGameObjectWithTag("Partner"))
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
