using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindItem_Tutorial : MonoBehaviour
{
    private float RunTime;
    private bool FirstTime;

    public float TimePanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == TutorialController.player)
        {
            RunTime = TimePanel;
            FirstTime = true;
        }
    }
    private void Update()
    {
       // Debug.Log(RunTime);
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

            TutorialController.RunTutorial = 0;  //Stage 2

        }
    }
}

