using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class CheckEnemyAttackRange : Node
{
    private Transform _transform;
    private Animator enemyAnim;

    private static int _playerLayerMask = 1 << 7;

    public CheckEnemyAttackRange(Transform transform)
    {
        _transform = transform;
        enemyAnim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform target = (Transform)t;
        if (Vector3.Distance(_transform.position, target.position) <= Enemy.attackRange)
        {
            enemyAnim.SetBool("isWalking", false);
            enemyAnim.SetBool("isAttacking", true);

            state = NodeState.SUCCESS;
            return state;
        }
        else
        {
            enemyAnim.SetBool("isAttacking", false);
        }

        state = NodeState.FAILURE;
        return state;
    }
}
