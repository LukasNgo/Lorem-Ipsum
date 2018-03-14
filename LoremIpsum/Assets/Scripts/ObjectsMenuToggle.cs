using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ObjectsMenuToggle : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;
    public GameObject menu;

    //private bool m_menuState;

    private void Start()
    {
        //m_menuState = menu.activeInHierarchy;

        //if (m_menuState)
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
            //m_menuState = !m_menuState;
        }
    }

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
        //m_menuState = !m_menuState;
        //menu.SetActive(m_menuState);

        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }
}
