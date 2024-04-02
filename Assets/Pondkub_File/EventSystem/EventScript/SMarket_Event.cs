using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMarket_Event : MonoBehaviour
{
    
    
    public float PanalTime;
    public float PanelTimeDelay;
    private float RunTime;

    private bool FirstTime;
    public static bool OpenPanelDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player && !FirstTime)
        {
            Debug.Log("hit");
            EventController.RunEvent = 1;
            //gameObject.SetActive(false);
            FirstTime = true;
            RunTime = PanalTime;
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
            if (RunTime <= PanalTime - PanelTimeDelay)
            {
                OpenPanelDelay = true;

            }
        }
       
        if (RunTime <= 0 && FirstTime)
        {
            EventController.RunEvent = 2;
        }
    }
}
