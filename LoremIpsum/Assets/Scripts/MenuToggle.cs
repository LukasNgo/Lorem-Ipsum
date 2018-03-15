using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MenuToggle : MonoBehaviour {

    public VRTK_ControllerEvents R_controllerEvents;
    public VRTK_ControllerEvents L_controllerEvents;
    public GameObject menu;

    public bool PlayerMode = false;
    public bool BuildMode = false;
    //public bool LinkMode = false;

    private bool menuState = false;
    

    private void OnEnable()
    {
        L_controllerEvents.ButtonTwoPressed += L_controllerEvents_ButtonTwoPressed;
        R_controllerEvents.ButtonTwoPressed += R_controllerEvents_ButtonTwoPressed;
    }

    private void OnDisable()
    {
        L_controllerEvents.ButtonTwoPressed -= L_controllerEvents_ButtonTwoPressed;
        R_controllerEvents.ButtonTwoPressed -= R_controllerEvents_ButtonTwoPressed;
    }

    private void R_controllerEvents_ButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
    {
        ChangeState();
    }

    private void L_controllerEvents_ButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
    {
        if (BuildMode != true)
        {
            ChangeState();
        }
    }

    public void ChangeState()
    {
        menuState = !menuState;
        menu.SetActive(menuState);

        if (PlayerMode == true)
        {
            GetComponent<VRTK_Pointer>().enableTeleport = !menuState;
        }
        else if (BuildMode == true)
        {
            R_controllerEvents.gameObject.GetComponent<PlaceObjects>().MenuUp(menuState);
        }
        else
        {
            //Link Mode stuff
        }

    }

    public void ChangePlayerMode(bool updateMode)
    {
        PlayerMode = updateMode;
    }

    public void ChangeBuildMode(bool updateMode)
    {
        BuildMode = updateMode;
    }
}
