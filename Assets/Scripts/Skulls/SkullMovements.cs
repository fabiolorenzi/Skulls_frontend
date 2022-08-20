using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullMovements : MonoBehaviour
{
    private float speed = 50f;

    public void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
