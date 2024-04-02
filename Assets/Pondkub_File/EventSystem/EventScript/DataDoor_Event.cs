using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDoor_Event : MonoBehaviour
{

    public float PanelTime;
    private float Runtime;

    private bool FirstTime;

    public GameObject Camera;
    public GameObject Camera_DataDoorEvent;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player && !FirstTime)
        {
            EventController.RunEvent = 9;
            Camera.SetActive(false);
            Camera_DataDoorEvent.SetActive(true);
            FirstTime = true;
            Runtime = PanelTime;
        }
    }
    private void Update()
    {
        TimeEvent();
    }

    void TimeEvent()
    {
        if (Runtime > 0)
        {
            Runtime -= Time.deltaTime;
        }
        if (Runtime <= 0 && FirstTime)
        {

            Camera.SetActive(true);
            EventController.RunEvent = 10;
            Destroy(gameObject);

        }
    }
}
