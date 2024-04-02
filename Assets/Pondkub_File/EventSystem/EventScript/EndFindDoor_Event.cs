using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFindDoor_Event : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player)
        {
            EventController.RunEvent = 6;
            Destroy(gameObject);
        }
    }
   
}
