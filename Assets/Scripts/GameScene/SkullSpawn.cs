using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullSpawn : MonoBehaviour
{
    public Transform[] entryPoints;

    private bool started = false;
    private int currentNumber;

    public void Start()
    {
        foreach (Transform pos in entryPoints)
        {
            InstantiateRandomPosition(Random.Range(0, 2), pos);
            started = true;
        };
    }

    public void Update()
    {
        if (started)
        {
            currentNumber = GameObject.FindGameObjectsWithTag("Skull").Length;
            if (currentNumber == 0)
            {
                foreach (Transform pos in entryPoints)
                {
                    InstantiateRandomPosition(Random.Range(0, 1), pos);
                };
            }
        }
    }

    public void InstantiateRandomPosition(int typeIndex, Transform initialPosition)
    {
        Vector3 initialPositionPoint = new Vector3(initialPosition.position.x, initialPosition.position.y, initialPosition.position.z);
        string resource;
        if (typeIndex == 1)
        {
            resource = "Skulls/LifeSkull";
        }
        else
        {
            resource = "Skulls/MetalSkull";
        }
        Instantiate(Resources.Load(resource, typeof(GameObject)), initialPositionPoint, Quaternion.identity);
    }
}
