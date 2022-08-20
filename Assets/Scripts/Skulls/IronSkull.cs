using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronSkull : MonoBehaviour
{
    [SerializeField]
    private Player playerSO;

    private float skullValue = 3;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            playerSO.currentShuriken += skullValue;
            Destroy(this.gameObject);
        }
    }
}
