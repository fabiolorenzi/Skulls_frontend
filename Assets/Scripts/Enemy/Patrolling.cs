using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class Patrolling : Node
{
    private Transform _transform;
    private NavMeshAgent navMeshAgent;
    private Transform[] _waypoints;
    private Animator enemyAnim;

    private int _currentWayPoint = 0;

    private float _waitingTime = 3f;
    private float _waitingCounter = 0f;
    private bool _waiting = false;

    public Patrolling(Transform transform, Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints;
        enemyAnim = transform.GetComponent<Animator>();
        navMeshAgent = transform.GetComponent<NavMeshAgent>();
    }

    public override NodeState Evaluate()
    {
        if (_waiting)
        {
            _waitingCounter += Time.deltaTime;
            if (_waitingCounter >= _waitingTime)
            {
                _waiting = false;
            }
        }
        else
        {
            Transform wp = _waypoints[_currentWayPoint];
            if (Vector3.Distance(_transform.position, wp.position) < 0.5f)
            {
                _transform.position = wp.position;
                _waitingCounter = 0f;
                _waiting = true;
                _currentWayPoint = Random.Range(0, _waypoints.Length - 1);
                enemyAnim.SetBool("isWalking", false);
            }
            else
            {
                navMeshAgent.transform.position = Vector3.MoveTowards(_transform.position, wp.position, 5 * Time.deltaTime);
                navMeshAgent.transform.LookAt(wp.position);
                enemyAnim.SetBool("isWalking", true);
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}