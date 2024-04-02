using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneralTypeManager : MonoBehaviour
{
    public GeneralTypeAnimatorManager generalTypeAnimatorManager;
    public GeneralTypeCombatManager generalTypeCombatManager;
    public GeneralStatManager generalStatManager;
    public IdleState startingState;

    public float FindPlayerSpeed;

    [Header("Flags")]
    public bool isPerformingAction;
    public bool isDead;
    public bool canRotation;
    public float Timer;
    public float RoarTimer;
    public float RoarCooldown;

    [Header("Current State")]
    [SerializeField] private State currentState;

    [Header("Current Target")]
    public PlayerManager currentTarget;
    public Vector3 targetDirection;
    public float distanceCurrentTarget;
    public float viewableAngleTarget;

    [Header("Animator")]
    public Animator animator;

    [Header("NavMesh Agent")]
    public NavMeshAgent generalNavMeshAgent;
    public Transform[] waypoints;
    private int waypointIndex;
    private Vector3 waypointTarget;

    [Header("Rigibody")]
    public Rigidbody generalTypeRigibody;

    [Header("Motion")]
    public float rotationSpeed = 5f;
    public float Speed = 0.8f;

    [Header("Attack")]
    public float attackCoolDownTime;
    public float minimunAttackDistance = 0.6f;
    public float maximunAttackDistance = 1f;
    [Header("Alien SFX")]
    public AudioClip alienRoarSFXClip;
    public AudioSource alienSFXSource;

    public Vector3 wanderPoint;
    [SerializeField] float wanderRadius = 3f;

    private void Awake()
    {
        currentState = startingState;
        animator = GetComponent<Animator>();
        generalNavMeshAgent = GetComponent<NavMeshAgent>();
        generalTypeRigibody = GetComponent<Rigidbody>();
        generalTypeAnimatorManager = GetComponent<GeneralTypeAnimatorManager>();
        generalTypeCombatManager = GetComponent<GeneralTypeCombatManager>();
        generalStatManager = GetComponent<GeneralStatManager>();
        wanderPoint = RandomPoint();
        if (waypoints.Length > 0)
        { FindWayPoint(); }
    }
    private void FixedUpdate()
    {
        if (!isDead)
        {
            HandleStateMachine();
        }
    }
    private void Update()
    {
       


        if (attackCoolDownTime > 0)
        {
            attackCoolDownTime -= Time.deltaTime;
        }

        if (currentTarget != null && !isPerformingAction )
        {
            generalNavMeshAgent.speed = FindPlayerSpeed;
            generalNavMeshAgent.angularSpeed = 120f;
            targetDirection = currentTarget.transform.position - transform.position;
            viewableAngleTarget = Vector3.SignedAngle(targetDirection, transform.forward, Vector3.up);
            distanceCurrentTarget = Vector3.Distance(currentTarget.transform.position, transform.position);

            
        }
        if(currentTarget == null)
        {
            generalNavMeshAgent.speed = FindPlayerSpeed;
            generalNavMeshAgent.angularSpeed = 120f;
            
            Patrol();
            Timer += Time.deltaTime;
        }
        RoarTimer += Time.deltaTime;
        if(RoarTimer > RoarCooldown)
        {
            alienSFXSource.PlayOneShot(alienRoarSFXClip);
            RoarTimer = 0;
        }
    }
    private void HandleStateMachine()
    {
        State nextState;
        if (currentState != null)
        {
            nextState = currentState.Tick(this);
            if (nextState != null)
            {
                currentState = nextState;
            }
        }
    }
    private void Wander()
    {
        if (Vector3.Distance(transform.position, wanderPoint) < 1f)
        {
            wanderPoint = RandomPoint();
        }
        else
        {
            animator.SetFloat("Vertical", 1, 0.2f, 1 * Time.deltaTime);
            generalNavMeshAgent.enabled = true;
            generalNavMeshAgent.speed = Speed;
            generalNavMeshAgent.angularSpeed = 60f;
            generalNavMeshAgent.SetDestination(wanderPoint);
        }
    }
    public Vector3 RandomPoint()
    {
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navMesh;
        NavMesh.SamplePosition(randomPoint, out navMesh, wanderRadius, -1);
        return new Vector3(navMesh.position.x, transform.position.y, navMesh.position.z);
    }
    public void Disable()
    {
        isPerformingAction = true;
        generalNavMeshAgent.speed = 0f;
    }
    public void Enable()
    {
        isPerformingAction = false;
        generalNavMeshAgent.speed = FindPlayerSpeed;
    }
    public void Patrol()
    {
        
        animator.SetFloat("Vertical", 1, 0.2f, Time.deltaTime);
        if (Vector3.Distance(transform.position, waypointTarget) < 0.5f)
        {
            UpdateWayPointIndex();
            if (Timer <= 6)
            {
                animator.SetFloat("Vertical", 0, 0, Time.deltaTime);
            }
            if (Timer >= 6)
            {
                FindWayPoint();
                Timer = 0;
                
            }
        }
    }
    public void FindWayPoint()
    {
        if (waypoints.Length != 0)
        {
            waypointTarget = waypoints[waypointIndex].position;
            generalNavMeshAgent.SetDestination(waypointTarget);
        }
    }
    public void UpdateWayPointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
