using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Tutorial : MonoBehaviour
{
    private float RunTime;
    private bool FirstTime = false;

    public float TimePanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == TutorialController.player)
        {
            TutorialController.RunTutorial = 8;
            RunTime = TimePanel;
            FirstTime = true;
        }
    }
    private void Update()
    {
        //Debug.Log(TutorialController.RunTutorial);
        Reload_Tutorial.OffPanelOpendoor = true;
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

            TutorialController.RunTutorial = -1;
            Destroy(gameObject);

        }
    }
}
