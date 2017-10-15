using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poacher_smallTalk : MonoBehaviour {

   public string[] textToDisplay;

    public Sprite textBox;

	// Use this for initialization
	void Start () {
    

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine("triggerTalk");
        }
    }

   IEnumerator triggerTalk()
    {
        var rand = Random.Range(1, 10);
        if (rand <= 7)
        {
            yield return new WaitForSeconds(3);
            GetComponentInChildren<SpriteRenderer>().sprite = textBox;
            GetComponentInChildren<TextMesh>().text = textToDisplay[Random.Range(0, textToDisplay.Length)];
            yield return new WaitForSeconds(5);
            GetComponentInChildren<SpriteRenderer>().sprite = null;
            GetComponentInChildren<TextMesh>().text = null;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
