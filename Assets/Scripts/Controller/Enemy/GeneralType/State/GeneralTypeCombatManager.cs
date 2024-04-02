using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralTypeCombatManager : MonoBehaviour
{
    [Header("Attack Damage")]
    public int grappleBiteDamage = 33;

    GeneralTypeManager generalTypeManager;
    GeneralTypeDamageCollider rightHand;
    GeneralTypeDamageCollider leftHand;

    private void Awake()
    {
        generalTypeManager = GetComponent<GeneralTypeManager>();
        LoadDamageCollider();
    }
    public void SetAttackType(GeneralTypeAttack attackType)
    {
        rightHand.attackType = attackType;
        leftHand.attackType = attackType;
    }
    private void LoadDamageCollider()
    {
        GeneralTypeDamageCollider[] damageColliders = GetComponentsInChildren<GeneralTypeDamageCollider>();

        foreach (var damageCollider in damageColliders)
        {
            if (damageCollider.isRightHandGrapple)
            {
                rightHand = damageCollider;
            }
            else
            {
                leftHand = damageCollider;
            }
        }
    }
    public void OpenDamageCollider()
    {       
        rightHand.grappleCollider.enabled = true;
        leftHand.grappleCollider.enabled = true;         
    }
    public void CloseDamageCollider()
    {
        rightHand.grappleCollider.enabled = false;
        leftHand.grappleCollider.enabled = false;
    }
    public void EnableRotationDurinAattack()
    {
        generalTypeManager.canRotation = true;
    }
    public void DisableRotationDurinAattack()
    {
        generalTypeManager.canRotation = false;
    }
}
