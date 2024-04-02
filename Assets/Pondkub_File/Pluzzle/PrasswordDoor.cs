using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrasswordDoor : MonoBehaviour
{
    public GameObject PinPanel;
    public GameObject EventPlayer;

    private bool isRange;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == EventPlayer)
        {
            isRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == EventPlayer)
        {
            isRange = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && isRange)
        {
            PinPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
       


    }
}
