using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : PlatformMover
{
    
    /* [SerializeField] Vector3 movement ;
     [Range(-0.01f, 0.01f)] [SerializeField] float movementFactor;
     [SerializeField] float period = 3f;
     Vector3 startingPos;
     void Start()
     {
         startingPos = transform.position; 

     }

     // Update is called once per frame
     void Update()
     {
         float cycles = Time.time / period;
         const float tau = Mathf.PI * 2f;
         float RawSineWve = Mathf.Sin(cycles * tau);
         movementFactor = RawSineWve / 2f + 0.5f;
         transform.position = transform.position + movement*movementFactor;
     }*/
}
