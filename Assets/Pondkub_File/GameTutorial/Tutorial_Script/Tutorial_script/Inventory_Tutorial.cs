using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Tutorial : MonoBehaviour
{
    private bool InRage;
    public static bool OffPanelOpendoor;




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == TutorialController.player)
        {      
            InRage = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && InRage)
        {
            OffPanelOpendoor = true;
            TutorialController.RunTutorial = 5;

        }
    }
}
