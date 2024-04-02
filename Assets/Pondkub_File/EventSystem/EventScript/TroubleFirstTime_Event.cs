using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroubleFirstTime_Event : MonoBehaviour
{
    private bool FirstTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player && !FirstTime)
        {
            EventController.RunEvent = 22;
            FirstTime = true;
        }
    }
}
