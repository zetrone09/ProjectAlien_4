using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDataRoom_Event : MonoBehaviour
{
    private bool InRange;
    private bool FirstTime;

    public float DeleyTimeEvent;
    private float Runtime;
    public float TimeToPanel;
    //public GameObject DemoDoorDestroy;

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
        //Debug.Log("RunTime "+ Runtime);
       if(Input.GetKey(KeyCode.F) && InRange && !FirstTime)
        {
            Runtime = DeleyTimeEvent;
            FirstTime = true;
           
            //Destroy(gameObject);
        }


       if(Runtime > 0)
        {
            Runtime = Runtime - Time.deltaTime;
            //Debug.Log("Eiei");
            if (Runtime <= TimeToPanel && FirstTime )
            {
                //Debug.Log("on DEEEE");
                EventController.RunEvent = 14;
            }
        }
        
        if (Runtime <= 0 && FirstTime)
        {
            //Debug.Log("in DEER");
            EventController.RunEvent = 15;
            Destroy(gameObject);

        }
        
    }
}
