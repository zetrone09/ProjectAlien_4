using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFindRunner_Event : MonoBehaviour
{
    public GameObject Alien_FindRunner;
    public GameObject Event_FindRunner;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == EventController.player)
        {
            //Alien_FindRunner.SetActive(false);
            Destroy(Alien_FindRunner);
            Destroy(gameObject);
        }
    }
}
