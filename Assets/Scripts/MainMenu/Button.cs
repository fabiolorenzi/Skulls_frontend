using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    private Text text;
    private MenuSound menuSound;

    private Color baseColour = new Color (50f/255f, 50f/255f, 50f/255f, 255f/255f);
    private Color hoverColour = new Color(164f/255f, 152f/255f, 0, 255f/255f);

    public void Start()
    {
        text = GetComponentInChildren<Text>();
        menuSound = GetComponentInParent<MenuSound>();
    }

    public void OnButtonHover()
    {
        menuSound.PlaySound(menuSound.hoverSound);
        text.color = hoverColour;
    }

    public void OnButtonLeave()
    {
        text.color = baseColour;
    }

    public void OnButtonClick()
    {
        menuSound.PlaySound(menuSound.acceptSound);
    }
}
