using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class EnemyAttack : Node
{
    private Animator enemyAnim;
    private Transform _lastTarget;

    private float attackTime = 1f;
    private float attackCounter = 0f;
    public static float attackPower = 20f;
    public static bool isAttacking = false;

    public EnemyAttack(Transform transform)
    {
        enemyAnim = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (target != _lastTarget)
        {
            _lastTarget = target;
        }

        attackCounter += Time.deltaTime;
        if (attackCounter >= attackTime)
        {
            enemyAnim.SetBool("isAttacking", true);
            attackTime++;
            isAttacking = true;
        }
        else
        {
            enemyAnim.SetBool("isAttacking", false);
            isAttacking = false;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
