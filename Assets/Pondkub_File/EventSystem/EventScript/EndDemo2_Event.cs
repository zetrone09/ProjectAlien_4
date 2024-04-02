using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDemo2_Event : MonoBehaviour
{
    public GameObject EndDemo_Pannel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player)
        {
            EndDemo_Pannel.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = false;
        }
    }
}
