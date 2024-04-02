using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    PursueTargetState pursueTargetState;

    [Header("Detect Lavyer")]
    [SerializeField] LayerMask detectionLayer;

    [Header("Detect Eye LineCast")]
    [SerializeField] float characterHeight = 1.3f;
    [SerializeField] LayerMask ignoreCollider;

    [Header("Detect Radius")]
    [SerializeField] float detectRadiusInSight = 5f;
    [SerializeField] float detectRadiusHearing = 2f;    

    [Header("Detect Angle")]
    [SerializeField] float minimumDetectRadiusAngle = -100f;
    [SerializeField] float maximumDetectRadiusAngle = 180f;

    [Header("Alien SFX")]
    public AudioClip alienRoarSFXClip;
    public AudioSource alienSFXSource;

   

    private void Awake()
    {
        pursueTargetState = GetComponent<PursueTargetState>();        
    }
    public override State Tick(GeneralTypeManager generalTypeManager)
    {
        if (generalTypeManager.currentTarget != null)
        {
            return pursueTargetState;
        }
        else
        {
            FindATargetInSight(generalTypeManager);
            HearATarget(generalTypeManager);
            return this;
        }
    }
    private void FindATargetInSight(GeneralTypeManager generalTypeManager)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectRadiusInSight, detectionLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            PlayerManager player = colliders[i].transform.GetComponent<PlayerManager>();

            if (player != null)
            {
                Vector3 targetDirection = transform.position - player.transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                if (viewableAngle > minimumDetectRadiusAngle && viewableAngle < maximumDetectRadiusAngle)
                {
                    RaycastHit hit;

                    Vector3 playerStartPoint = new Vector3(player.transform.position.x, characterHeight, player.transform.position.z);
                    Vector3 GeneralStartPoint = new Vector3(transform.position.x, characterHeight, transform.position.z);

                    Debug.DrawLine(playerStartPoint, GeneralStartPoint, Color.red);

                    if (Physics.Linecast(playerStartPoint, GeneralStartPoint, out hit, ignoreCollider))
                    {
                        generalTypeManager.currentTarget = null;
                    }
                    else
                    {
                        if (!player.isDead)
                        {
                            //generalTypeManager.currentTarget = player;
                            //alienSFXSource.PlayOneShot(alienRoarSFXClip);
                            //generalTypeManager.generalTypeAnimatorManager.PlayActionAnimation("Generaltype_roar_01");
                            if(Vector3.Distance(transform.position,player.transform.position)<=detectRadiusInSight)
                            {
                                generalTypeManager.currentTarget = player;
                                alienSFXSource.PlayOneShot(alienRoarSFXClip);
                                generalTypeManager.generalTypeAnimatorManager.PlayActionAnimation("Generaltype_roar_01");

                            }
                           else
                            {
                                generalTypeManager.currentTarget = null;
                            }    
                        }                       
                    }
                }
            }
        }
    }

    private void HearATarget(GeneralTypeManager generalTypeManager)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectRadiusHearing, detectionLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            PlayerManager player = colliders[i].transform.GetComponent<PlayerManager>();

            if (player != null)
            {
                if (!player.isDead)
                {
                    generalTypeManager.currentTarget = player;
                    alienSFXSource.PlayOneShot(alienRoarSFXClip);
                    generalTypeManager.generalTypeAnimatorManager.PlayActionAnimation("Generaltype_roar_01");
                }
            }
        }
    }
}
