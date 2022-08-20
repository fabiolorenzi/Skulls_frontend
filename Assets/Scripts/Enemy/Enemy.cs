using System.Collections.Generic;
using BehaviourTree;

public class Enemy : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;
    public static float fovRange = 20f;
    public static float attackRange = 3f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>()
            {
                new CheckEnemyAttackRange(transform),
                new EnemyAttack(transform)
            }),
            new Sequence(new List<Node>()
            {
                new CheckEnemyInRange(transform),
                new GoToTarget(transform)
            }),
            new Patrolling(transform, waypoints)
        });
        return root;
    }
}