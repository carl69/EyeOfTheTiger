using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock_24Hour : MonoBehaviour {   

public int playTime = 0;
private int seconds = 0;
private int minutes = 0;
private int hours = 0;

public int ingameSeconds;

public bool isNight = false;
public bool isDay = false;

private Text textClock;

public int day = 0;
// Use this for initialization
void Start()
{
    textClock = GetComponent<Text>();
    StartCoroutine("Playtimer");
}

private IEnumerator Playtimer()
{
    while (true)
    {
        yield return new WaitForSeconds(1);
        playTime += ingameSeconds;
        seconds = (playTime % 60);
        minutes = (playTime / 60) % 60;
        hours = (playTime / 3600) % 24;
        if (hours >= 24)
        {
                
            playTime = 0;
        }
        if (hours >= 21 || hours <= 5)
        {
            isNight = true;
            isDay = false;
        }
        else isNight = false;
        if (hours >= 6 && hours <= 20 && isDay == false)
        {
                day++;
                isDay = true;
                isNight = false;
        }
        
    }


}

// Update is called once per frame
void Update()
{

    textClock.text = "24 Hour Clock = " + hours.ToString() + " : " + minutes.ToString() + " : " + seconds.ToString() + " : ";
} 

}