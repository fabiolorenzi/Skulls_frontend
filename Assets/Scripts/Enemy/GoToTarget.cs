using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class GoToTarget : Node
{
    private Transform _transform;
    private NavMeshAgent navMeshAgent;
    private Animator enemyAnim;

    public GoToTarget(Transform transform)
    {
        _transform = transform;
        navMeshAgent = transform.GetComponent<NavMeshAgent>();
        enemyAnim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (Vector3.Distance(_transform.position, target.position) > 1.5f)
        {
            navMeshAgent.destination = target.position;
            enemyAnim.SetBool("isWalking", true);
        }
        else
        {
            enemyAnim.SetBool("isWalking", false);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
