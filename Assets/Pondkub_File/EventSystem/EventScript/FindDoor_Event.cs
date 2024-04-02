using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDoor_Event : MonoBehaviour
{

    public float CameraTime;
    private float RunTime;
    
    public GameObject Camera;
    public GameObject Camera_Event;
    private bool FirstTime;

    public float TimeToPanel;
    public static bool RunPanel;

    public static bool SetKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player && !FirstTime)
        {
            EventController.RunEvent = 5;
            if (!SetKey)
            { 
            Camera.SetActive(false);
            Camera_Event.SetActive(true);
            }
            FirstTime = true;
            RunTime = CameraTime;  
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
            //Debug.Log(CameraTime - TimeToPanel);
            //Debug.Log(RunTime);
            RunTime -= Time.deltaTime;
            if (RunTime <=  CameraTime - TimeToPanel)
            {
                RunPanel = true;
                
            }
        }

        if (RunTime <= 0 && FirstTime)
        {
            if (!SetKey)
            {
                Camera.SetActive(true);
                Camera_Event.SetActive(false);
            }
            EventController.RunEvent = 6;
           
        }
    }
}
