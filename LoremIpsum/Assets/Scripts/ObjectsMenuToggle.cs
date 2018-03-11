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
        controllerEvents.TouchpadPressed += controllerEvents_TouchpadPressed;
    }

    private void OnDisable()
    {
        controllerEvents.TouchpadPressed -= controllerEvents_TouchpadPressed;
    }

    private void controllerEvents_TouchpadPressed(object sender, ControllerInteractionEventArgs e)
    {
        //if (!m_menuState)
        if (!menu.activeInHierarchy)
        {
            menu.SetActive(true);
            //m_menuState = !m_menuState;
        }
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
