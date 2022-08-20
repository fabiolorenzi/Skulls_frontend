using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float speed = 1f;

    public void Update()
    {
        transform.Rotate(-Vector3.up * speed * Time.deltaTime);
    }
}
