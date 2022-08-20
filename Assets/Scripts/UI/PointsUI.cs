using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsUI : MonoBehaviour
{
    private TextMeshProUGUI textUI;
    public static float points;

    public void Start()
    {
        textUI = GetComponent<TextMeshProUGUI>();
        points = 0;
    }

    public void Update()
    {
        textUI.text = "Points: " + points;
    }

    public static void SetPoints(float addPoints)
    {
        points += addPoints;
    }
}
