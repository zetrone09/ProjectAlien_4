using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemQuest_Event : MonoBehaviour
{
    private bool InRange;

    public float PanelTime;
    private float Runtime;

    public bool FirstTime;
    public bool EndCode;

    public static int numOfItem;
    public GameObject[] panel;
    public GameObject[] CameraSet;
    public GameObject[] Panel_ItemPopUp;
    

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
        if (!EndCode)
        {
            InputKey();
            TimePanel();
            //Debug.Log("Num"+numOfItem);
            //Debug.Log("FirstTime" + FirstTime);
        }

    }

    void TimePanel()
    {
        if (Runtime > 0)
        {
            Runtime -= Time.deltaTime;
        }
        if (Runtime <= 0 && FirstTime)
        {
            EndCode = true;
            panel[numOfItem-1].SetActive(false);
            CameraSet[numOfItem - 1].SetActive(false);
            Panel_ItemPopUp[0].SetActive(false);
            
            
           

            //EventController.RunEvent = 8;
        }
    }
    void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.F) && InRange && !FirstTime)
        {
            //EventController.RunEvent = 7;
            Runtime = PanelTime;
            FirstTime = true;
            numOfItem += 1;

            panel[numOfItem - 1].SetActive(true);
            CameraSet[numOfItem - 1].SetActive(true);
            Panel_ItemPopUp[0].SetActive(true);
            
        }
    }
}
