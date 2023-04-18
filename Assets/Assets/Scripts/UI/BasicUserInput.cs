using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUserInput : MonoBehaviour
{
    [SerializeField] GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void LoadGame()
    {
        gm.instance.LoadGame();    
    }

    public void LoadMainMenu()
    {
        gm.instance.LoadMainMenu();
    }

    public void ExitApplication()
    {
        gm.instance.ExitApplication();
    }
}
