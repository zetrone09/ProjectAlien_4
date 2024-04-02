using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightRunner_Event : MonoBehaviour
{
    private bool FirstTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player && !FirstTime)
        {
            EventController.RunEvent = 19;
            FirstTime = true;
        }
    }
}
