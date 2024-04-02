using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckBroken2 : MonoBehaviour
{
    public GameObject Alien_TruckBroken2;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == EventController.player)
        {
            Alien_TruckBroken2.SetActive(true);
            Destroy(gameObject);
        }
    }
}
