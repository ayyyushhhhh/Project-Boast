using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{public GameObject[] PopUps;
Rocket rocket;
Button FloatButton;
private int popUpIndex;
   float timeVal = 2f;
    void Update()
    {
       
     
        if(popUpIndex==0){
       PopUps[popUpIndex].SetActive(true);
timeVal -= Time.deltaTime; 

if(timeVal <= 0){
    PopUps[popUpIndex].SetActive(false);
    popUpIndex++;
}
        }
        else if(popUpIndex ==1){
             Debug.Log("Joystick");
          
              PopUps[popUpIndex].SetActive(true);
           timeVal -= Time.deltaTime; 
           Debug.Log(timeVal);
if(timeVal <= -2f){
    PopUps[popUpIndex].SetActive(false);
        popUpIndex++;
}
        }
        else if(popUpIndex ==2){
        
           
              PopUps[popUpIndex].SetActive(true);
           timeVal -= Time.deltaTime; 
if(timeVal <=-4f){
    PopUps[popUpIndex].SetActive(false);
        popUpIndex++;
}
        }
        else if(popUpIndex ==3){
           
            
              PopUps[popUpIndex].SetActive(true);
            timeVal -= Time.deltaTime; 
if(timeVal <= -6f){
    PopUps[popUpIndex].SetActive(false);
        popUpIndex++;
}

        }
                else if(popUpIndex ==4){
           
            
              PopUps[popUpIndex].SetActive(true);
            timeVal -= Time.deltaTime; 
if(timeVal <= -8f){
    PopUps[popUpIndex].SetActive(false);
        popUpIndex++;
}

        }

    }
// IEnumerator MakeItTrue(){
//     yield return new WaitForSeconds(2f);
//     PopUps[popUpIndex].SetActive(false);
//     if(popUpIndex<4){
//     popUpIndex++;}
    
// }

}
