using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "A.I/Action/Attack Action")]
public class AttackAction : ScriptableObject
{
    [Header("Attack Type")]
    public GeneralTypeAttack attackType;

    [Header("Attack Animation")]
    public string attackAnimation;

    [Header("Attack Cooldowm")]
    public float attackCoolDown = 5f;

    [Header("Attack angle & distance")]
    public float maximunAttackAngle = 20f;
    public float minimunAttackAngle = -20f;
    public float maximunAttackDistance = 1f;
    public float minimunAttackDistance = 0.6f;
}
