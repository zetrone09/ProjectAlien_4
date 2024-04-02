using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckBroken_Event : MonoBehaviour
{

    public float PanelTime;

    private bool FirstTime;
    private float RunTime;

   //public static bool[] PanelCheck_Number =  new bool[3];
   
    public static int RunPanel;
    public float[] TimeToPanel;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player && !FirstTime)
        {
            EventController.RunEvent = 3;
            FirstTime = true;
            RunTime = PanelTime;
            
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
            if (RunTime <= PanelTime - TimeToPanel[RunPanel])
            {
                if (RunPanel < TimeToPanel.Length - 1)
                {
                    RunPanel = RunPanel + 1;
                }
            }

            //PanelCheck_Number[RunPanel] = true;
            //Debug.Log("runpanel   " + RunPanel);
            //if (RunTime <= PanelTime - TimeToPanel[RunPanel])
            //{

                //    if (RunPanel < TimeToPanel.Length-1)
                //    {
                //        PanelCheck_Number[RunPanel] = false;

                //        RunPanel = RunPanel + 1;
                //    }


                //    //Debug.Log("aaaa++   " + RunPanel);
                //}

        }

        if (RunTime <= 0 && FirstTime)
        {
            EventController.RunEvent = 4;
        }
    }
}
