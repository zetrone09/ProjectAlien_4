using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComDoor_Event : MonoBehaviour
{
    public float PanelTime;
    private float Runtime;

    private bool FirstTime;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player && !FirstTime)
        {
            EventController.RunEvent = 11;
            FirstTime = true;
            Destroy(gameObject);
            
        }
    }
    private void Update()
    {
        
    }

    void TimeEvent()
    {
        if (Runtime > 0)
        {
            Runtime -= Time.deltaTime;
        }
        if (Runtime <= 0 && FirstTime)
        {

            
            EventController.RunEvent = 10;
            Destroy(gameObject);

        }
    }
}
