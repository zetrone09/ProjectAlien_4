using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_Tutorial : MonoBehaviour
{

    private bool InRage;

   


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

            TutorialController.RunTutorial = 3;
            
        }
        //if(Input.GetKeyDown(KeyCode.B))
        //{

            //TutorialController.RunTutorial = 0;
            
        //}
    }
}
