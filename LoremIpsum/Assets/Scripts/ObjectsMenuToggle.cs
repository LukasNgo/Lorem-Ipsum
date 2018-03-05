using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMenuToggle : MonoBehaviour {

    public GameObject menu;

    private bool menuState = false;

    public void ChangeState()
    {
        menuState = !menuState;
        menu.SetActive(menuState);
    }
}
