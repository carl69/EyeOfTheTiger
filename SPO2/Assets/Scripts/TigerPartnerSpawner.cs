using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerPartnerSpawner : MonoBehaviour {
    public GameObject Partner;
    food Pfood;
    GameObject player;
    public float spendingfood = 0;
    float betweeAdds;
	// Use this for initialization
	void Start () {
        
        player = GameObject.FindGameObjectWithTag("Player");
        Pfood = player.GetComponent<food>();
        
    }

    // Update is called once per frame
    void Update () {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Pfood = player.GetComponent<food>();
        }

        if (Input.GetKey(KeyCode.F))
        {
            if (Pfood.eaten >= 10)
            {
                if (spendingfood == 0)
                {
                    Pfood.eaten -= 10;
                    spendingfood = 10;
                }



                if (Pfood.eaten >= 15)
                {
                    if (spendingfood == 10)
                    {
                        Pfood.eaten -= 10;
                        spendingfood = 20;


                        if (!GameObject.FindGameObjectWithTag("Partner") && !GameObject.FindGameObjectWithTag("Cub"))
                        {
                            SpawnPartner();
                        }

                    }
                }
            }





        }
        else if (spendingfood != 0)
        {
            Pfood.eaten += spendingfood;
            spendingfood = 0;
        }
    }
    void SpawnPartner() {
        int SpawnPoint = Random.Range(0, transform.childCount);
        GameObject partnerSpawner = this.gameObject.transform.GetChild(SpawnPoint).gameObject;
        Instantiate(Partner, new Vector3(partnerSpawner.transform.position.x, partnerSpawner.transform.position.y, 0), Quaternion.identity);
    }
}
