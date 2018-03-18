using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;

public class MenuToggle : MonoBehaviour {

    public VRTK_ControllerEvents R_controllerEvents;
    public VRTK_ControllerEvents L_controllerEvents;
    public GameObject menu;

    public bool PlayerMode = false;
    public bool BuildMode = false;
    //public bool LinkMode = false;

    public Color[] playerColors;
    public Color[] buildColors;
    public Color[] linkColors;

    private bool menuState = false;

    private void Start()
    {
        ChangeMenuColors();
    }

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

    public void ChangeMenuColors()
    {
        Color[] newColors;

        if (PlayerMode == true)
        {
            newColors = playerColors;
        }
        else if (BuildMode == true)
        {
            newColors = buildColors;
        }
        else
        {
            newColors = linkColors;
        }

        for (int i = 0; i < menu.GetComponentsInChildren<Button>().Length; i++)
        {
            ColorBlock newColor = menu.GetComponentsInChildren<Button>()[i].colors;
            newColor.normalColor = newColors[0];
            newColor.highlightedColor = newColors[1];
            newColor.pressedColor = newColors[2];

            menu.GetComponentsInChildren<Button>()[i].colors = newColor;

            Debug.Log("Changing colors " + i);
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
