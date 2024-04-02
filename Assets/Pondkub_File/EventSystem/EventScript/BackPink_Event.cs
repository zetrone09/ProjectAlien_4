using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPink_Event : MonoBehaviour
{
    public GameObject Alien_BackPink;
    private bool InRange;
    private bool FirstTime;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player)
        {

            InRange = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == EventController.player)
        {

            InRange = false;

        }
    }
    private void Update()
    {
       
        if (Input.GetKey(KeyCode.F) && InRange && !FirstTime)
        {
            Alien_BackPink.SetActive(true);
            FirstTime = true;
            
        }
    }
}
