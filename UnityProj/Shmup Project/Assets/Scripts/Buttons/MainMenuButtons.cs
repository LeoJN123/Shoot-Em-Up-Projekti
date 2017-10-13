using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour {
    public Canvas mainCanvas;
    public Canvas optionsCanvas;

    void Awake()
    {
        optionsCanvas.enabled = false;
    }
    public void OptionsOn()
    {
        optionsCanvas.enabled = true;
        mainCanvas.enabled = false;
    }
    public void ReturnOn()
    {
        optionsCanvas.enabled = false;
        mainCanvas.enabled = true;
    }

    public void GameStart()
    {

    }
}
