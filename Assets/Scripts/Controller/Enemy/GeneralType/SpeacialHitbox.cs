using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeacialHitbox : MonoBehaviour
{
    public GeneralType generalType;
    public PlayerController playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (generalType.IsGrapple)
            {
                other.GetComponent<PlayerController>().hit(generalType.specialdamage);
                generalType.IsGrapple = false;
                playerController.disable = false;
            }
        }
    }
}
