using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;

public class MenuToggle : MonoBehaviour {

    public VRTK_ControllerEvents R_controllerEvents;
    public VRTK_ControllerEvents L_controllerEvents;
    public GameObject menu;

    public GameObject inPlayMenu;

    public GameObject modeText;
    public GameObject modePanel;

    public bool PlayerMode = false;
    public bool BuildMode = false;

    public bool playing = false;

    public string[] modeTitles;

    public Color[] playerColors;
    public Color[] buildColors;
    public Color[] linkColors;

    private bool menuState = false;
    private bool playingMenuState = false;

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
        if (playing == false)
        {
            ChangeState();
        }
        else
        {
            PlayingMenu();
        }
    }

    private void L_controllerEvents_ButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
    {
        if (playing == false)
        {
            if (BuildMode != true)
            {
                ChangeState();
            }
        }
        else
        {
            PlayingMenu();
        }
    }

    public void ChangeMenuToPlaying(bool isPlaying)
    {
        playing = isPlaying;
        //modeText.SetActive(!playing);
    }

    public void PlayingMenu()
    {
        playingMenuState = !playingMenuState;
        inPlayMenu.SetActive(playingMenuState);
    }

    public void ChangeState()
    {
        menuState = !menuState;
        menu.SetActive(menuState);

        if (BuildMode == true)
        {
            R_controllerEvents.gameObject.GetComponent<PlaceObjects>().MenuUp(menuState);
        }

    }

    public void ChangeMenuColors()
    {
        Color[] newColors;

        if (PlayerMode == true)
        {
            newColors = playerColors;
            modeText.GetComponent<Text>().text = modeTitles[0];
        }
        else if (BuildMode == true)
        {
            newColors = buildColors;
            modeText.GetComponent<Text>().text = modeTitles[1];
        }
        else
        {
            newColors = linkColors;
            modeText.GetComponent<Text>().text = modeTitles[2];
        }

        for (int i = 0; i < menu.GetComponentsInChildren<Button>().Length; i++)
        {
            ColorBlock newColor = menu.GetComponentsInChildren<Button>()[i].colors;
            newColor.normalColor = newColors[0];
            newColor.highlightedColor = newColors[1];
            newColor.pressedColor = newColors[2];

            menu.GetComponentsInChildren<Button>()[i].colors = newColor;
        }

        modeText.GetComponent<Text>().color = newColors[2];
        modePanel.GetComponent<Image>().color = newColors[0];

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
