using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PursueTargetState : State
{
    AttackState attackState;
  

    [Header("Attack list")]
    public AttackAction[] normalAttacks;
    public Transform playerTransform;

    [Header("Perform Attack now")]
    public List<AttackAction> potenrialAttacks;
    private void Awake()
    {
        attackState = GetComponent<AttackState>();
    }
    public override State Tick(GeneralTypeManager generalTypeManager)
    {
        if (generalTypeManager.isPerformingAction)
        {
            RotationTowardTargetWhilestAttack(generalTypeManager);
            generalTypeManager.animator.SetFloat("Vertical", 0, 0.2f, Time.deltaTime);
            return this;
        }

        MoveTowardsCurrentTarget(generalTypeManager);
        RotationTowardTarget(generalTypeManager);

        if (generalTypeManager.distanceCurrentTarget <= generalTypeManager.maximunAttackDistance)
        {
            
            if (attackState.currentAttack == null)
            {
                GetNewAttack(generalTypeManager);
                return this;
            }
            else
            {
                generalTypeManager.generalNavMeshAgent.enabled = false;
                return attackState;
            }           
        }
        else
        {        
            return this;
        }        
    }
    private void MoveTowardsCurrentTarget(GeneralTypeManager generalTypeManager)
    {
        //generalTypeManager.animator.SetFloat("Vertical", 1, 0.2f, Time.deltaTime);
        //generalTypeManager.generalNavMeshAgent.enabled = true;
        generalTypeManager.generalNavMeshAgent.enabled = true;
        NavMeshPath path = new NavMeshPath();
        if (NavMesh.CalculatePath(transform.position, playerTransform.position, NavMesh.AllAreas, path))
        {
            generalTypeManager.animator.SetFloat("Vertical", 2, 0.2f, Time.deltaTime);
            generalTypeManager.generalNavMeshAgent.SetPath(path);
        }
    }
    private void RotationTowardTarget(GeneralTypeManager generalTypeManager)
    {
        if (generalTypeManager.canRotation)
        {
            generalTypeManager.generalNavMeshAgent.enabled = true;
            generalTypeManager.generalNavMeshAgent.SetDestination(generalTypeManager.currentTarget.transform.position);
            generalTypeManager.transform.rotation = Quaternion.Slerp(generalTypeManager.transform.rotation,
                                                                    generalTypeManager.generalNavMeshAgent.transform.rotation,
                                                                    generalTypeManager.rotationSpeed / Time.deltaTime);
        }
        
    }
    private void RotationTowardTargetWhilestAttack(GeneralTypeManager generalTypeManager)
    {
        if (generalTypeManager.canRotation)
        {
            Vector3 direction = generalTypeManager.currentTarget.transform.position - generalTypeManager.transform.position;
            direction.y = 0;
            direction.Normalize();

            if (direction == Vector3.zero)
            {
                direction = generalTypeManager.transform.forward;
            }
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            generalTypeManager.transform.rotation = Quaternion.Slerp(generalTypeManager.transform.rotation, targetRotation, generalTypeManager.rotationSpeed * Time.deltaTime); ;
        }
    }
    private void GetNewAttack(GeneralTypeManager generalTypeManager)
    {
        for (int i = 0; i < normalAttacks.Length; i++)
        {
            AttackAction normalAttack = normalAttacks[i];

            if (generalTypeManager.distanceCurrentTarget <= normalAttack.maximunAttackDistance &&
                generalTypeManager.distanceCurrentTarget >= normalAttack.minimunAttackDistance)
            {
                if (generalTypeManager.viewableAngleTarget <= normalAttack.maximunAttackAngle &&
                    generalTypeManager.viewableAngleTarget >= normalAttack.minimunAttackAngle)
                {
                    potenrialAttacks.Add(normalAttack);
                }
            }
        }

        int randomValue = Random.Range(0, potenrialAttacks.Count);

        if (potenrialAttacks.Count > 0)
        {
            attackState.currentAttack = potenrialAttacks[randomValue];
            potenrialAttacks.Clear();
        }
    }
}
