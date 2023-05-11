using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowControls : MonoBehaviour
{
    public GameObject controlMenu;
    public GameObject Canvas;

    public void ShowControlMenu()
    {
        controlMenu.SetActive(true);
        Canvas.SetActive(false);
    }

    public void ShowMainMenu()
    {
        controlMenu.SetActive(false);
        Canvas.SetActive(true);
    }
}
