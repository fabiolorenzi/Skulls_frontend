using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearEnemy : MonoBehaviour
{
    [SerializeField]
    private Player playerSO;

    public void Update()
    {
        if (playerSO.isDead || PauseGame.isStopped)
        {
            Destroy(this.gameObject);
        }
    }
}
