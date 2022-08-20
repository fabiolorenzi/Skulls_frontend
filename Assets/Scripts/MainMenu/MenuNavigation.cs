using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    private GameManager gameManager;

    public void Awake()
    {
        gameManager = GameManager.instance;
    }

    public void LoadGame()
    {
        gameManager.LoadGame();
    }

    public void BestScore()
    {
        gameManager.LoadBestScores();
    }

    public void Options()
    {
        gameManager.LoadOptions();
    }

    public void Exit()
    {
        gameManager.Exit();
    }
}
