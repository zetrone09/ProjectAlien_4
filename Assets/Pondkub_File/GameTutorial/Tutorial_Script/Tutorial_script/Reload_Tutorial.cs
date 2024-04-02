using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload_Tutorial : MonoBehaviour
{
    private float RunTime;
    private bool FirstTime = false;
    public static bool OffPanelOpendoor;

    public float TimePanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == TutorialController.player)
        {
            TutorialController.RunTutorial = 7;
            RunTime = TimePanel;
            FirstTime = true;
        }
    }
    private void Update()
    {
        
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
            if (!OffPanelOpendoor)
            { TutorialController.RunTutorial = 0; }
            Destroy(gameObject);

        }
    }
}
