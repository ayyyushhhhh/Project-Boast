using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Setiings : MonoBehaviour
{
public Slider JoystickSlider;
Rocket RocketJoystick;
float JoystickSliderValue=100;
void Start(){
    RocketJoystick = FindObjectOfType<Rocket>();
}
void Update(){
   JoystickSliderValue =  JoystickSlider.value;
// RocketJoystick.sideThrust = PlayerPrefs.SetFloat("Value",JoystickSliderValue);


 
}
}
