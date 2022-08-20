using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] initialPositions;

    private int enemyNumber;
    private int maxNumber;
    private int middlePoint = 10;
    private bool started = false;

    public void Start()
    {
        maxNumber = 20;
        foreach (Transform pos in initialPositions)
        {
            InstantiateRandomPosition("Rhinoceros", pos);
            started = true;
        };
    }

    public void Update()
    {
        if (started)
        {
            enemyNumber = GameObject.FindGameObjectsWithTag("enemy").Length;
            middlePoint = (maxNumber / 10) * 9;
            if (enemyNumber < middlePoint)
            {
                foreach (Transform pos in initialPositions)
                {
                    InstantiateRandomPosition("Rhinoceros", pos);
                };
                maxNumber += 20;
            }
        }
    }

    public void InstantiateRandomPosition(string resource, Transform initialPosition)
    {
        Vector3 initialPositionPoint = new Vector3(initialPosition.position.x, initialPosition.position.y, initialPosition.position.z);
        Instantiate(Resources.Load(resource, typeof(GameObject)), initialPositionPoint, Quaternion.identity);
    }
}
