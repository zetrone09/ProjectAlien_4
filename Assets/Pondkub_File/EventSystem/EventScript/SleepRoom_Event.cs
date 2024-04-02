using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepRoom_Event : MonoBehaviour
{
    
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player )
        {
            
            EventController.RunEvent = 20;
            Destroy(gameObject);
        }
    }

}
