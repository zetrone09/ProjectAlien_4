using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;  
    PauseMenu pauseMenu;

    [Header("Aiming Constraints")]
    public MultiAimConstraint spine01;
    public MultiAimConstraint spine02;
    public MultiAimConstraint head;

    RigBuilder rigBuilder;
    PlayerManager playerManager;
    PlayerMotionManager playerMotionManager;

    float snappedHorizontal;
    float snappedVertical;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerManager = GetComponent<PlayerManager>();
        playerMotionManager = GetComponent<PlayerMotionManager>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        rigBuilder = FindObjectOfType<RigBuilder> ();
    }
    public void PlayAnimation(string transformAnimation, bool isPeformingAction)
    {
        animator.SetBool("isPreformingAction", isPeformingAction);
        animator.SetBool("disableRootMotion", true);
        animator.applyRootMotion = false;
        animator.CrossFade(transformAnimation, 0.2f);
    }
    public void HandleAnimatorValue(float horizontalMovement, float verticalMovement, bool isRunning)
    {
        if (horizontalMovement > 0)
        {
            snappedHorizontal = 1;
        }
        else if (horizontalMovement < 0)
        {
            snappedHorizontal = -1;
        }
        else
        {
            snappedHorizontal = 0;
        }

        if (verticalMovement > 0)
        {
            snappedVertical = 1;
        }
        else if (verticalMovement < 0)
        {
            snappedVertical = -1;
        }
        else
        {
            snappedVertical = 0;
        }

        if (isRunning && snappedVertical > 0)
        {
            snappedVertical = 2;
        }

        animator.SetFloat("Horizontal", snappedHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat("Vertical", snappedVertical, 0.1f, Time.deltaTime);
    }
    public void UpdateAimContraints()
    {
        if (playerManager.isAiming)
        {
            spine01.weight = 0.3f;
            spine02.weight = 0.3f;
            head.weight = 0.7f;
        }
        else
        {
            spine01.weight = 0f;
            spine02.weight = 0f;
            head.weight = 0f;
        }
    }
    private void OnAnimatorMove()
    {
        if (playerManager.disableRootMotion)
        {
            return;
        }
        if (pauseMenu.isPaused)
        {
            return;
        }

        if (Time.timeScale != 0)
        {
            Vector3 animationDeltaPosition = animator.deltaPosition;
            animationDeltaPosition.y = 0;

            Vector3 velocity = animationDeltaPosition / Time.deltaTime;

            playerMotionManager.playerRigibody.drag = 0;
            playerMotionManager.playerRigibody.velocity = velocity;
            transform.rotation *= animator.deltaRotation;
        }
                          
    }
}
