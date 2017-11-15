using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {
    public string InfoMovement = "";
    public float playerSpeed, jumphight, gravity, Running;
    public string InfoFood = "";
    public float maxHunger = 100f, startHunger,hungerSpeed, foodPickUp;
    public string InfoWater = "";
    public float maxWater, startWater, waterLossRate,waterLossAmount, waterPickUp;

    private void Awake()
    {
        startHunger = PlayerPrefs.GetFloat("Food");
    }

}
