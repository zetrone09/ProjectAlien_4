using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralTypeDamageCollider : MonoBehaviour
{
    GeneralTypeManager generalTypeManager;

    [Header("Collider")]
    public Collider grappleCollider;

    [Header("Damage Collider Hand")]
    public bool isRightHandGrapple;

    [Header("Curreant Attack Type")]
    public GeneralTypeAttack attackType;

    [Header("Damage")]
    public int damageAmount = 25;

    private void Awake()
    {
        generalTypeManager = GetComponentInParent<GeneralTypeManager>();
        grappleCollider = GetComponent<Collider>();            
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerManager player = other.GetComponent<PlayerManager>();
            if (player != null)
            {
                DecideAttackAction(player);
            }          
        }
    }
    private void DecideAttackAction(PlayerManager player)
    {
        if (attackType == GeneralTypeAttack.grapple)
        {
            if (!player.isPreformingAction)
            {
                generalTypeManager.generalTypeAnimatorManager.PlayGrappleAnimation("Generaltype_Grapple_01", false);
                generalTypeManager.animator.SetFloat("Vertical", 0);

                player.animatorManager.PlayAnimation("player_GrappleReact", true);
                player.playerStatManager.pendingDamage = generalTypeManager.generalTypeCombatManager.grappleBiteDamage;
               

                Quaternion targetEnemyRorarion = Quaternion.LookRotation(player.transform.position);
                generalTypeManager.transform.rotation = targetEnemyRorarion;

                Quaternion targetPlayRorarion = Quaternion.LookRotation(generalTypeManager.transform.position);
                player.transform.rotation = targetPlayRorarion;
            }
        }
        else if (attackType == GeneralTypeAttack.swipe)
        {
            player.animatorManager.PlayAnimation("player_damage_01", true);
            player.playerStatManager.TakeDamage(damageAmount);
        }
    }
}
