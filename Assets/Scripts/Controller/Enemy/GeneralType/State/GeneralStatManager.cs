using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralStatManager : MonoBehaviour
{
    GeneralTypeManager generalTypeManager;

    [Header("Damage Modifiers")]
    public float headShotDamageMultipler = 1.5f;

    [Header("Max Heahth")]
    public int maxHealth = 100;

    [Header("Head Heahth")]
    public int headHealth = 100;

    [Header("UpperBody Heahth")]
    public int torseHealth = 100;
    public int leftArmHealth = 100;
    public int rightArmHealth = 100;

    [Header("LowerBody Heahth")]
    public int leftLegHealth = 100;
    public int rightLegHealth = 100;

    Collider m_Collider;
    private void Awake()
    {
        generalTypeManager = GetComponent<GeneralTypeManager>();
        m_Collider = GetComponent<Collider>();
    }
    public void HeadShotDamage(int damage)
    {
        headHealth = headHealth - Mathf.RoundToInt(damage * headShotDamageMultipler);
        maxHealth = maxHealth - Mathf.RoundToInt(damage * headShotDamageMultipler);
        CheckForDeath();
    }
    public void TorseShotDamage(int damage)
    {
        torseHealth = torseHealth - damage;
        maxHealth = maxHealth - damage;
        CheckForDeath();
    }
    public void ArmShotDamage(bool leftArmDamge, int damage)
    {
        if (leftArmDamge)
        {
            leftArmHealth = leftArmHealth - damage;

        }
        else
        {
            rightArmHealth = rightArmHealth - damage;

        }
        CheckForDeath();
    }
    public void LegShotDamage(bool leftLegDamge, int damage)
    {
        if (leftLegDamge)
        {
            leftLegHealth = leftLegHealth - damage;

        }
        else
        {
            rightLegHealth = rightLegHealth - damage;

        }
        CheckForDeath();
    }
    private void CheckForDeath()
    {
        if (maxHealth <= 0)
        {
            maxHealth = 0;
            generalTypeManager.isDead = true;
            generalTypeManager.generalTypeAnimatorManager.PlayActionAnimation("Generaltype_Death_01");
            Destroy(gameObject, 6f);
        }
    }
}
