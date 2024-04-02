using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRunner_Event : MonoBehaviour
{
    public float AllTime;
    public float PanelTime;
    private float Runtime;
    private bool FirstTime;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == EventController.player && !FirstTime)
        {
            EventController.RunEvent = 16;
            Runtime = AllTime;
            FirstTime = true;
        }
    }
    private void Update()
    {
        TimeSet();
    }
    void TimeSet()
    {
        if(Runtime > 0)
        {
            Runtime -= Time.deltaTime;
            //if(Runtime <= PanelTime)
            //{
            //    EventController.RunEvent = 17;
            //}
        }
        if (Runtime <= 0 && FirstTime)
        {
            EventController.RunEvent = 18;
            this.gameObject.SetActive(false);
        }
    }
}
