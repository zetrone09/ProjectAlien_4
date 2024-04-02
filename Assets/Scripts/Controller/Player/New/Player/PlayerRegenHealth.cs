using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRegenHealth : MonoBehaviour
{
    PlayerManager playerManager;
    float deleyHealth = 0;
    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }
    void Update()
    {
        if (playerManager.RegenHealth)
        {           
            deleyHealth += Time.deltaTime;
            playerManager.playerStatManager.playerHealth += Time.deltaTime;
            if (deleyHealth > 25)
            {
                playerManager.RegenHealth = false;
            }
        }
    }
}
