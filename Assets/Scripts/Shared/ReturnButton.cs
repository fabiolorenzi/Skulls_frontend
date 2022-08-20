using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private string from;

    public void Awake()
    {
        gameManager = GameManager.instance;
    }

    public void LoadMainMenu()
    {
        gameManager.LoadMainMenu(from);
    }
}
