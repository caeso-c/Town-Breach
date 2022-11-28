using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRadius = 9f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;
    Transform target; // target is the player

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        if (health.IsDead()) // if enemy is dead, disable script and navmeshagent
        {
            enabled = false;
            navMeshAgent.enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }

        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (isProvoked) // first checks if isProvoked is enabled, which will activate in else if - if player is within chaseRadius
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRadius) // enemy will always at least chase player if player steps within chaseRadius
        {
            isProvoked= true;
        }
    }

    public void OnDamageTaken() // if enemy takes damage, enable provoked
    {
        isProvoked = true;
    }

    void EngageTarget()
    {
        FaceTarget();

        // stopping distance (in navMeshAgent) is how far enemy will stop once it reaches player
        if (distanceToTarget >= navMeshAgent.stoppingDistance) // this will allow enemy to keep chasing even if player is outside of chaseRadius
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance) // if enemy reaches player, it stops and attacks
        {
            AttackTarget();
        }
    }

    void ChaseTarget() // chases player
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        if (!health.IsDead()) // if isDead is false
        {
            navMeshAgent.SetDestination(target.position); // after each frame, move or set destination of navMeshAgent to be whereever the player is
        }
        
    }

    void AttackTarget() // attacks player
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }

    void FaceTarget() // rotates enemy in the direction of the player (target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed); // rotate smoothly between 2 vectors
    }

    void OnDrawGizmosSelected() // display markers for chaseRadius when enemy is selected
    {
        Gizmos.color = new Color(1, 0, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
