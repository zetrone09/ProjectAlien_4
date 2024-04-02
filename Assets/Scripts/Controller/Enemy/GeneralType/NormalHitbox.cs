using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalHitbox : MonoBehaviour
{
    public GeneralType generalType;
    public PlayerController playerController;
    private void OnTriggerEnter(Collider other)
    {      
            if (!generalType.IsGrapple)
            {
                if (other.tag == "Player")
                {
                    other.GetComponent<PlayerController>().hit(generalType.damage);
                }
            }  
    }
    
}
