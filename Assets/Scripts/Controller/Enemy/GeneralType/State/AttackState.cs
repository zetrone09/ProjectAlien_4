using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class AttackState : State
 {
    PursueTargetState pursueTargetState;

    [Header("Current Attack now")]
    public AttackAction currentAttack;

    [Header("State Flags")]
    public bool hasPerformAttack;

    private void Awake()
    {
        pursueTargetState = GetComponent<PursueTargetState>();      
    }    
    public override State Tick(GeneralTypeManager generalTypeManager)
    {
        generalTypeManager.animator.SetFloat("Vertical", 0, 0.2f, Time.deltaTime);

        if (generalTypeManager.currentTarget.isDead)
        {
            return this;
        }

        if (generalTypeManager.distanceCurrentTarget > generalTypeManager.maximunAttackDistance)
        {
            return pursueTargetState;
        }
        
        if (generalTypeManager.isPerformingAction)
        {
            generalTypeManager.animator.SetFloat("Vertical", 0, 0.2f, Time.deltaTime);
            return this;
        }
        if (!hasPerformAttack && generalTypeManager.attackCoolDownTime <= 0)
        {                 
            AttackTarget(generalTypeManager);
        }
        if (hasPerformAttack)
        {
            ResetStateFlags();
            return pursueTargetState;
        }
        else if (currentAttack == null)
        {
            return pursueTargetState;
        }
        else
        {
            return this;
        }        
    } 
    private void AttackTarget(GeneralTypeManager generalTypeManager)
    {
        if (currentAttack != null)
        {
            hasPerformAttack = true;
            generalTypeManager.generalTypeCombatManager.SetAttackType(currentAttack.attackType);
            generalTypeManager.attackCoolDownTime = currentAttack.attackCoolDown;
            generalTypeManager.generalTypeAnimatorManager.PlayAttackAnimation(currentAttack.attackAnimation);
        }
    }
    private void ResetStateFlags()
    {
        hasPerformAttack = false;

        currentAttack = null;
    }
}


