using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPinkKey_Event : MonoBehaviour
{
    private bool InRange;

    public float PanelTime;
    private float Runtime;

    private bool FirstTime;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player)
        {

            InRange = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == EventController.player)
        {

            InRange = false;

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && InRange && !FirstTime)
        {
            EventController.RunEvent = 12;
            Runtime = PanelTime;
            FirstTime = true;
        }


        if (Runtime > 0)
        {
            Runtime -= Time.deltaTime;
        }
        if (Runtime <= 0 && FirstTime)
        {
            EventController.RunEvent = 13;
            Destroy(gameObject);
        }
    }
}
