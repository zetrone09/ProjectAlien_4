using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBoss_Event : MonoBehaviour
{
    private bool FirstTime;
    public GameObject alianBoss;
    public GameObject newCamera;
    public GameObject oldCamera;

    
    public float TimeSet;
    public float Runtime;
    private bool False = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EventController.player && !FirstTime)
        {
            Runtime = TimeSet;
            FirstTime = true;
            alianBoss.SetActive(true);
            oldCamera.SetActive(false);
            newCamera.SetActive(true);
}
    }

    private void Update()
    {
        if (Runtime > 0)
        { Runtime -= Time.deltaTime; }
        if(Runtime <= 0)
        {
            oldCamera.SetActive(true);
            newCamera.SetActive(false);
        }
    }
}
