using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneralType : MonoBehaviour
{
    public enum wanderType { Random,Waypoint };
    public wanderType WanderType;
    public Animator ani;
    public LayerMask occlusionLayers;

    public GameObject target;
    public Transform[] wayPoint;
    private float enemyFov = 45f;
    private float viewDistance = 4f;
    private float radius = 4f;
    [SerializeField] private float wanderSpeed = 1f;
    [SerializeField] private float chasesSpeed = 1.5f;
    private float loseThreshold = 2f;
    [SerializeField] private float health = 100f;
    public float damage = 25f;
    public float specialdamage = 50f;

    private bool IsAware = false;
    private bool IsDetecting = false;
    private bool IsDeath = false;
    private bool IsDisable = true;
    private bool IsAttack = true;
    public bool IsGrapple = true;
    private Vector3 wanderPoint;
    private NavMeshAgent agent;
    private int wayPointIndex = 0;
    private float loseTimer = 0;
    private float ZombieDecay = 0f;
    private float DeathDecay = 10f;
    public float SpAttackTimer = 10f;

    public Collider[] ragdollColliders;
    public Rigidbody[] ragdollRigidbody;

    [Header("Sound")]
    public AudioClip RoarSound;
    public AudioSource audioSource;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        wanderPoint = RandomPoint();

        foreach (Collider collider in ragdollColliders)
        {  
                collider.enabled = false;                      
        }
        foreach (Rigidbody rb in ragdollRigidbody)
        {
            rb.isKinematic = true;
        }
    }
    void Update()
    {
        if (!IsDeath)
        {
            //player in of range
            if (IsAware && IsDisable)
            {
                ani.SetBool("OnAware", true);
                Roar();    
                //Move
                agent.SetDestination(target.transform.position);
                ani.SetBool("OnChase", true);
                agent.transform.LookAt(target.transform.position);
                agent.speed = chasesSpeed;
                ani.SetBool("OnAware", false);
                //Attack
                if (IsAttack)
                {
                    ani.SetTrigger("OnGrapple");
                    if (IsGrapple)
                    {
                        OnSpeacialAttack();                                                                          
                    }
                    else
                    {
                        OnAttack();
                    }
                } 
                //Cheack player out of range
                if (Vector3.Distance(target.transform.position, transform.position) > viewDistance)
                {
                loseTimer += Time.deltaTime;
                if (loseTimer >= loseThreshold)
                {
                    DisAware();
                }
                }
                //cooldownSpattack
                SpAttackTimer -= Time.deltaTime;
                if (SpAttackTimer < 0)
                {
                    IsGrapple = true;
                    SpAttackTimer = 10f;
                }
                IsAttack = true;
                
                //behine environment
                if (!IsDetecting)
                {
                    loseTimer += Time.deltaTime;
                    if (loseTimer >= loseThreshold)
                    {
                        DisAware();
                    }                 
                }
            }
            //player out of range
            else if (!IsAware && !IsDisable)
            {
                if (Vector3.Distance(wayPoint[wayPointIndex].position, transform.position) > 1f)
                {
                    wander();
                    agent.speed = wanderSpeed;
                }
                else
                {
                    ani.SetBool("OnWander", false);
                    ani.SetBool("OnChase", false);
                }
            }
            SeacrchforPlayer();                   
        }
        //Delete game obj
        else
        {
            ZombieDecay += Time.deltaTime;
            if (ZombieDecay >= DeathDecay)
            {
                Delete();
            }
        }
        //Cheack Death
        if (health <= 0)
        {
            Death();
        }
    }
    public void SeacrchforPlayer()
    {
        Vector3 origin = transform.position;
        Vector3 destination = target.transform.position;
        origin.y += 1 / 2;
        destination.y = origin.y;
        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(destination)) < enemyFov)
        {
            if (Vector3.Distance(destination, origin) < viewDistance && Vector3.Distance(destination, origin) > 2)
            {
                RaycastHit hit;
                if (Physics.Linecast(origin, destination, out hit, occlusionLayers))
                {             
                    if (hit.transform.tag == "Player")
                    {
                        OnAware();  
                    }
                }
                else
                {
                    IsDetecting = false;
                }
            }           
        }
        //else
        //{
        //    IsDetecting = false;
        //}
    }
    public void OnAware()
    {   
        IsAware = true;
        IsDetecting = true;
        loseTimer = 0;     
    }
    public void DisAware()
    {
        ani.SetBool("OnChase", false);
        ani.SetBool("OnAttack", false);
        ani.SetBool("OnSpecialAttack", false);
        IsAware = false;
        loseTimer = 0;
    }
    public void wander()
    {
        if (WanderType == wanderType.Random)
        {
            if (Vector3.Distance(transform.position, wanderPoint) < 1f)
            {
                Debug.Log("point" + wayPoint[wayPointIndex]);
                wanderPoint = RandomPoint();
            }
            else
            {
                agent.SetDestination(wanderPoint);
            }
        }
        else
        {         
                if (Vector3.Distance(wayPoint[wayPointIndex].position, transform.position) < 1f)
                {
                    if (wayPointIndex == wayPoint.Length - 1)
                    {
                        wayPointIndex = 1;
                    }
                    else
                    {
                        wayPointIndex++;
                    }
                }
                else
                {
                    ani.SetBool("OnWander", true);
                    agent.SetDestination(wayPoint[wayPointIndex].position);
                }        
        }
        
    }
    public Vector3 RandomPoint()
    {
        Vector3 randomPoint = (Random.insideUnitSphere * radius) + transform.position;
        NavMeshHit navMesh;
        NavMesh.SamplePosition(randomPoint, out navMesh,radius,-1);
        return new Vector3(navMesh.position.x, transform.position.y, navMesh.position.z);
    }
    public void hit(float damage)
    {
        health -= damage;
        OnAware();
    }
    public void headShot(float damage)
    {
        health -= damage * 2;
    }
    public void Death()
    {
        IsDeath = true;
        ani.enabled = false;
        agent.speed = 0;

        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = true;
        }
        foreach (Rigidbody rb in ragdollRigidbody)
        {
            rb.isKinematic = false;
        }

        
    }
    public void Roar()
    {
        audioSource.PlayOneShot(RoarSound);
    }
    public void Delete()
    {
        Destroy(gameObject);
    }
    public void OnSpeacialAttack()
    {
        IsGrapple = false;
        ani.SetBool("OnSpecialAttack",true);
        ani.SetBool("OnAttack", false);
    }
    public void OnAttack()
    {
        IsAttack = false;
        ani.SetBool("OnSpecialAttack", false);
        ani.SetBool("OnAttack", true);
    }
    public void Disable()
    {
        IsDisable = false;
    }
    public void Anable()
    {
        IsDisable = true;
    }


}
