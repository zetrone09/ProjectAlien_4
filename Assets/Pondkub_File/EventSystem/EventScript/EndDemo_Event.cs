using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDemo_Event : MonoBehaviour
{
    public GameObject Event_EndDemo;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player)
        {
            Event_EndDemo.SetActive(true);
        }
    }

}
