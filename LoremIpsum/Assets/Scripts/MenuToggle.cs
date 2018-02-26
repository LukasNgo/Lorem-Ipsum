﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MenuToggle : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;
    public GameObject menu;

    public bool RightBuildController = false;
    public bool PlayerMode = false;

    private bool menuState = false;
    

    private void OnEnable()
    {
        controllerEvents.ButtonTwoPressed += controllerEvents_ButtonTwoPressed;
    }

    private void OnDisable()
    {
        controllerEvents.ButtonTwoPressed -= controllerEvents_ButtonTwoPressed;
    }

    private void controllerEvents_ButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
    {
        ChangeState();
    }

    public void ChangeState()
    {
        menuState = !menuState;
        menu.SetActive(menuState);

        if (PlayerMode == true)
        {
            GetComponent<VRTK_Pointer>().enableTeleport = !menuState;
        }
        else if (RightBuildController == true)
        {
            GetComponent<PlaceObjects>().MenuUp(menuState);
        }
    }

    public void ChangePlayerMode(bool updateMode)
    {
        PlayerMode = updateMode;
    }
}
