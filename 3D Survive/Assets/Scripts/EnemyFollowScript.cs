using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowScript : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    public float distanceToAttack = 0.5f;

    private Transform playerTarget;
    [SerializeField] Animator animator;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(playerTarget.position);

        if(navMeshAgent.remainingDistance <= distanceToAttack)
        {
            animator.SetBool("inAttackRange", true);
            navMeshAgent.isStopped = true;
        }
        else
        {
            animator.SetBool("inAttackRange", false);
            navMeshAgent.isStopped = false;
        }
    }
}
