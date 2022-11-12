using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target; // target is the player
    [SerializeField] float chaseRadius = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
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

    void EngageTarget()
    {
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

    void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position); // after each frame, move or set destination of navMeshAgent to be whereever the player is
    }

    void AttackTarget()
    {
        Debug.Log("You are under attack!");
    }

    void OnDrawGizmosSelected() // display markers for chaseRadius when enemy is selected
    {
        Gizmos.color = new Color(1, 0, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
