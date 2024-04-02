using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor_Tutorial : MonoBehaviour
{
    private float RunTime;
    private bool FirstTime = false;

    public float TimePanel;

    private void OnTriggerEnter(Collider other)
    {
       
            if (!FirstTime && other.gameObject == TutorialController.player)
        {
            TutorialController.RunTutorial = 4;
            RunTime = TimePanel;
            FirstTime = true;
        }
    }

    private void Update()
    {
        //Debug.Log(RunTime);
        TimePanelSet();
    }
    void TimePanelSet()
    {
        if (RunTime > 0)
        {
            RunTime -= Time.deltaTime;
        }
        if (RunTime <= 0 && FirstTime)
        {
            if (!Inventory_Tutorial.OffPanelOpendoor)
            {
                TutorialController.RunTutorial = 0;  //Stage 2
            }
            Destroy(gameObject);

        }
    }

}
