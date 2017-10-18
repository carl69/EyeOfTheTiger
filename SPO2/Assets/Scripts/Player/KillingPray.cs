using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingPray : MonoBehaviour {
    public GameObject food;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider c)
    {
		float number = Random.Range (1.0f, 3.9f);
		if (c.tag == "Pray" && Input.GetKey (KeyCode.LeftShift) && this.tag == "Player")
        {	
			print (number);
			if (number >= 1.0f && number < 2.0f) {
				Instantiate (food, new Vector3 (c.transform.position.x + 3, c.transform.position.y /*- 1*/, c.transform.position.z), Quaternion.identity);
			}
			if (number >= 2.0f && number < 3.0f) {
				Instantiate (food, new Vector3 (c.transform.position.x + 3, c.transform.position.y /*- 1*/, c.transform.position.z), Quaternion.identity);
				Instantiate(food, new Vector3(c.transform.position.x + 8, c.transform.position.y , c.transform.position.z), Quaternion.identity);
			}
		
			if (number >= 3.0f && number < 4.0f) {
				Instantiate (food, new Vector3 (c.transform.position.x + 3, c.transform.position.y /*- 1*/, c.transform.position.z), Quaternion.identity);
				Instantiate(food, new Vector3(c.transform.position.x + 8, c.transform.position.y , c.transform.position.z), Quaternion.identity);
				Instantiate(food, new Vector3(c.transform.position.x + 13, c.transform.position.y , c.transform.position.z), Quaternion.identity);
			}
            Destroy(c.gameObject);
        }
        if (c.tag == "Pray" && this.tag == "Mother")
        {
            //Instantiate(food, new Vector3(c.transform.position.x, c.transform.position.y - 1, c.transform.position.z), Quaternion.identity);
			if (number >= 1.0f && number < 2.0f) {
				Instantiate(food, new Vector3(c.transform.position.x + 3, c.transform.position.y - 1, c.transform.position.z), Quaternion.identity);
			}
			if (number >= 2.0f && number < 3.0f) {
				Instantiate(food, new Vector3(c.transform.position.x + 3, c.transform.position.y - 1, c.transform.position.z), Quaternion.identity);
				Instantiate(food, new Vector3(c.transform.position.x + 8, c.transform.position.y - 1, c.transform.position.z), Quaternion.identity);
			}

			if (number >= 3.0f && number < 4.0f) {
				Instantiate(food, new Vector3(c.transform.position.x + 3, c.transform.position.y - 1, c.transform.position.z), Quaternion.identity);
				Instantiate(food, new Vector3(c.transform.position.x + 8, c.transform.position.y - 1, c.transform.position.z), Quaternion.identity);
				Instantiate(food, new Vector3(c.transform.position.x + 13, c.transform.position.y - 1, c.transform.position.z), Quaternion.identity);
			}
            Destroy(c.gameObject);
        }
    }
}
