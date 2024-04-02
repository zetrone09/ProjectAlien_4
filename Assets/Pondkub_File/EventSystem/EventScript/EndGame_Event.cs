using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGame_Event : MonoBehaviour
{
    private bool IsRange;


    public GameObject Panel_Notend;
    private float Runtime;
    public float TimeSet;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player)
        {
            IsRange = true;
            
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == EventController.player)
        {
            IsRange = false;
            
           
        }
    }

    private void Update()
    {
        //Debug.Log("numofItem"+ GetItemQuest_Event.numOfItem);
        //Debug.Log(IsRange);
        if (GetItemQuest_Event.numOfItem < 4 && IsRange)
        {
            Panel_Notend.SetActive(true);
            Runtime = TimeSet;

        }
        if (GetItemQuest_Event.numOfItem == 4 && IsRange)
        {
            SceneManager.LoadSceneAsync("Ending");
        }

        if (Runtime > 0)
        {
            Runtime -= Time.deltaTime;
        }
        if (Runtime <= 0)
        {
            Panel_Notend.SetActive(false);
        }
    }



}
