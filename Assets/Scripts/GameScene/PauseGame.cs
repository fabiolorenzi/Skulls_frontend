using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBar;
    [SerializeField]
    private GameObject staminaBar;
    [SerializeField]
    private GameObject shurikenCounter;
    [SerializeField]
    private GameObject pointsCounter;
    [SerializeField]
    private GameObject pauseTitle;
    [SerializeField]
    private GameObject continueButton;
    [SerializeField]
    private GameObject returnButton;

    public static bool isPaused = false;
    public static bool isStopped = false;

    public void Start()
    {
        isStopped = false;
        Time.timeScale = 1;
        healthBar.SetActive(true);
        staminaBar.SetActive(true);
        shurikenCounter.SetActive(true);
        pointsCounter.SetActive(true);
        pauseTitle.SetActive(false);
        continueButton.SetActive(false);
        returnButton.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            PauseGameFunction();
        }
    }

    public void PauseGameFunction()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseTitle.SetActive(true);
            healthBar.SetActive(false);
            staminaBar.SetActive(false);
            shurikenCounter.SetActive(false);
            pointsCounter.SetActive(false);
            continueButton.SetActive(true);
            returnButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseTitle.SetActive(false);
            healthBar.SetActive(true);
            staminaBar.SetActive(true);
            shurikenCounter.SetActive(true);
            pointsCounter.SetActive(true);
            continueButton.SetActive(false);
            returnButton.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Restarter()
    {
        isStopped = true;
    }
}
