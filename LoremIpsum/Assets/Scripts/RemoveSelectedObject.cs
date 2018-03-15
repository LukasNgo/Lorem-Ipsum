using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class RemoveSelectedObject : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;
    private PlaceObjects m_placeObjects_script;
    private void Start()
    {
        m_placeObjects_script = GameObject.Find("P_RightController").GetComponent<PlaceObjects>();
    }

    private void OnEnable()
    {
        controllerEvents.GripReleased += controllerEvents_GripReleased;
    }

    private void OnDisable()
    {
        controllerEvents.GripReleased -= controllerEvents_GripReleased;
    }

    private void controllerEvents_GripReleased(object sender, ControllerInteractionEventArgs e)
    {
        RemoveObject();
    }

    private void RemoveObject()
    {
        m_placeObjects_script.ChangeSelectedObject(null);
    }
}
