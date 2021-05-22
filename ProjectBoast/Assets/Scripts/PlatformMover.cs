using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] Transform WaypointA;
    [SerializeField] Transform WaypointB;
    Vector3 TargetPosition;
    [SerializeField]float Speed =5f;
    void Start()
    {
        transform.position = WaypointA.position;
    }

    
  public  void Update()
    {
        MovePlatform();

    }

    public void MovePlatform()
    {
       if(transform.position == WaypointA.position)
        {
            Debug.Log("Start");
            TargetPosition = WaypointB.position;
        }
       else if(transform.position == WaypointB.position)
        {
            Debug.Log("End");
            TargetPosition = WaypointA.position;
        }
        
      transform.position=  Vector3.MoveTowards(transform.position, TargetPosition, Speed*Time.deltaTime);
    }
}
