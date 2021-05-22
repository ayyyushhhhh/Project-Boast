using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fuel : MonoBehaviour
{
    public float startFuel;
    public float MaxFuel = 100f;
    public float FuelConsumptionRate;
    public Slider fuelSid;
    public Text LowFuel;
 Immunity RocketImmunity;
    void Start()
    {RocketImmunity = FindObjectOfType<Immunity>();
        if(startFuel > MaxFuel) { startFuel = MaxFuel; }
        fuelSid.maxValue = MaxFuel;
        
        UpdateUI();
    }

    public void reduceFuel()
    {
        startFuel -= Time.deltaTime * FuelConsumptionRate;
        UpdateUI();
     
    }
    void UpdateUI()
    {
        fuelSid.value = startFuel;
        if(startFuel <= 0)
        {
            startFuel = 0;
            RocketImmunity.VideoAd = false;
            
        }
        else if(startFuel > 20)
        {
            LowFuel.gameObject.SetActive(false);
        }
        else if(startFuel <= 20)
        {
            LowFuel.gameObject.SetActive(true);
        }

    }
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.tag == "Fuel")
    //     {
    //         Destroy(collision.gameObject);
    //         if (startFuel > MaxFuel) { startFuel = MaxFuel; }
    //         else
    //         {
    //             startFuel = MaxFuel;
    //         }
    //     }
    // }
private void OnTriggerEnter(Collider collision)
    { if (collision.gameObject.tag == "Fuel")
        {
            Destroy(collision.gameObject);
            if (startFuel > MaxFuel) { startFuel = MaxFuel; }
            else
            {
                startFuel = MaxFuel;
            }
        }
       
    }
}
