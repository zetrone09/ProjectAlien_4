using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicControl_Tutorial : MonoBehaviour
{
    
    private float RunTime;
    private bool FirstTime;
    
    public float TimePanel;

   
    
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject == TutorialController.player)
        {
            RunTime = TimePanel;
            FirstTime = true;
        }
        
    }
    private void Start()
    {
        TutorialController.RunTutorial = 1;
    }
    private void Update()
    {
        TimePanelSet();
       
    }
    void TimePanelSet()
    {
        if(RunTime > 0)
        {
            RunTime -= Time.deltaTime;
        }
        if(RunTime <= 0 && FirstTime)
        {
            
            TutorialController.RunTutorial = 2;  //Stage 2
            
        }
    }
}
