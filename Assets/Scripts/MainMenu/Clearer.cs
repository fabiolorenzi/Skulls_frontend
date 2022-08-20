using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clearer : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 1;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach(GameObject en in enemies)
        {
            Destroy(en);
        }
        GameObject[] skulls = GameObject.FindGameObjectsWithTag("Skull");
        foreach (GameObject sk in skulls)
        {
            Destroy(sk);
        }
    }
}
