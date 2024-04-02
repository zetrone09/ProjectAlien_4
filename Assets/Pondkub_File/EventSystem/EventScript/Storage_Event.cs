using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage_Event : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player)
        {

            EventController.RunEvent = 21;
            Destroy(gameObject);
        }
    }
}
