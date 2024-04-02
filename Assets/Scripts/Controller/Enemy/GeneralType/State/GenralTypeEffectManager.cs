using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenralTypeEffectManager : MonoBehaviour
{
    GeneralTypeManager generalTypeManager;
    //[Header("VFX")]
    //public GameObject bloodVfx;
    //public Transform bloodPosition;



    private void Awake()
    {
        generalTypeManager = GetComponent<GeneralTypeManager>();
    }
    public void DamageHead(int damage)
    {
        //GameObject blood = Instantiate(bloodVfx);
        generalTypeManager.isPerformingAction = true;
        generalTypeManager.animator.CrossFade("Generaltype_React_HeadShot", 0.2f);
        generalTypeManager.generalStatManager.HeadShotDamage(damage);
    }
    public void DamageTorse(int damage)
    {
       // GameObject blood = Instantiate(bloodVfx);
        generalTypeManager.isPerformingAction = true;
        generalTypeManager.animator.CrossFade("Generaltype_ReactTorso_01", 0.2f);
        generalTypeManager.generalStatManager.TorseShotDamage(damage);
    }
    public void DamageLeftArm(int damage)
    {
        //GameObject blood = Instantiate(bloodVfx);
        generalTypeManager.isPerformingAction = true;
        generalTypeManager.animator.CrossFade("Generaltype_React_LArm", 0.2f);
        generalTypeManager.generalStatManager.ArmShotDamage(true,damage);
    }
    public void DamageRightArm(int damage)
    {
        //GameObject blood = Instantiate(bloodVfx);
        generalTypeManager.isPerformingAction = true;
        generalTypeManager.animator.CrossFade("Generaltype_React_RArm", 0.2f);
        generalTypeManager.generalStatManager.ArmShotDamage(false,damage);
    }
    public void DamageLeftLeg(int damage)
    {
        //GameObject blood = Instantiate(bloodVfx);
        generalTypeManager.isPerformingAction = true;
        generalTypeManager.animator.CrossFade("Generaltype_React_LLeg", 0.2f);
        generalTypeManager.generalStatManager.LegShotDamage(true, damage);
    }
    public void DamageRightLeg(int damage)
    {
        //GameObject blood = Instantiate(bloodVfx);
        generalTypeManager.isPerformingAction = true;
        generalTypeManager.animator.CrossFade("Generaltype_React_RLeg", 0.2f);
        generalTypeManager.generalStatManager.LegShotDamage(false, damage);
    }
}
