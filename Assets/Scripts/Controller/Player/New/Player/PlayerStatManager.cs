using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatManager : MonoBehaviour
{
    PlayerManager player;
    [SerializeField] PauseMenu pauseMenu;
    [Header("Health")]
    public float playerHealth = 100;

    [Header("Pending Damage")]
    public int pendingDamage = 0;

    [Header("Heal Health")]
    public float timerHeal = 0;




    private void Awake()
    {
        player = GetComponent<PlayerManager>();
    }
    private void KillPlayer()
    {
        if (!player.isPreformingAction)
        {
            player.animatorManager.PlayAnimation("plyaer_Death_01", true);
        }
        player.isDead = true;       
        pauseMenu.isPaused = true;
    }
    public void TakeDamageFormGrapple()
    {
        playerHealth = playerHealth - pendingDamage;
            
        if (playerHealth <= 0)
        {
            KillPlayer();
        }
    }
    public void TakeDamage(int damageTaken)
    {
        playerHealth = playerHealth - damageTaken;

        if (playerHealth <= 0)
        {
            KillPlayer();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            player.playerEquipmentManager.weapon.remainingAmmo = 100000;
            playerHealth = 150000000;
           
            
        }
        
    }

}
