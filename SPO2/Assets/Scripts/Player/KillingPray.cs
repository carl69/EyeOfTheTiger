using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingPray : MonoBehaviour {
    public GameObject food;

    public AudioSource PreyDeathSource;
    public AudioClip PreyDeathClip;

	// Use this for initialization
	void Start () {
        PreyDeathSource = GameObject.FindGameObjectWithTag("AudioController").transform.GetChild(1).transform.GetChild(5).GetChild(0).gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider c)
    {
		float number = Random.Range (1.0f, 3.9f);
		if (c.tag == "Pray" && Input.GetKey (KeyCode.LeftShift) && this.tag == "Player")
        {	
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
            PreyDeathSource.PlayOneShot(PreyDeathClip, 0.075f);
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
