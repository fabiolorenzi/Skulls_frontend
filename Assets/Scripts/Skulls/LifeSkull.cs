using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSkull : MonoBehaviour
{
    [SerializeField]
    private Player playerSO;

    private float skullValue = 40f;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (playerSO.currentLife + skullValue > playerSO.life)
            {
                playerSO.life += skullValue;
            }

            playerSO.currentLife += skullValue;
            Destroy(this.gameObject);
        }
    }
}
