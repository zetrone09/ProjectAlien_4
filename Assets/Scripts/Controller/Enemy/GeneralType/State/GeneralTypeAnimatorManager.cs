using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralTypeAnimatorManager : MonoBehaviour
{
    GeneralTypeManager generalTypeManager;

    private void Awake()
    {
        generalTypeManager = GetComponent<GeneralTypeManager>();
    }
    public void PlayAttackAnimation(string attackAnimation)
    {
        generalTypeManager.animator.applyRootMotion = true;
        generalTypeManager.isPerformingAction = true;
        generalTypeManager.animator.CrossFade(attackAnimation, 0.2f);
    }
    public void PlayActionAnimation(string actionAnimation)
    {
        generalTypeManager.animator.applyRootMotion = true;
        generalTypeManager.isPerformingAction = true;
        generalTypeManager.animator.CrossFade(actionAnimation, 0.2f);
    }
    public void PlayGrappleAnimation(string grappleAnimation, bool useRootMotion)
    {
        generalTypeManager.animator.applyRootMotion = useRootMotion;
        generalTypeManager.isPerformingAction = true;
        generalTypeManager.animator.CrossFade(grappleAnimation, 0.2f);
    }
}
