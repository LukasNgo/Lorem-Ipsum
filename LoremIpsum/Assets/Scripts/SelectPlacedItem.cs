﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SelectPlacedItem : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;
    public VRTK_BasePointerRenderer pointerRenderer;

    private PlaceObjects m_placeObject_script;
    private GameObject m_selected;

    private void OnEnable()
    { 
        controllerEvents.TriggerReleased += controllerEvents_TriggerReleased;
    }

    private void OnDisable()
    {
        controllerEvents.TriggerReleased -= controllerEvents_TriggerReleased;
    }

    private void Start()
    {
        m_placeObject_script = GameObject.Find("B_RightController").GetComponent<PlaceObjects>();
    }

    private void controllerEvents_TriggerReleased(object sender, ControllerInteractionEventArgs e)
    {
        m_selected = SelectObject();
        if (m_selected != null)
        {
            m_placeObject_script.ChangeSelectedObject(m_selected);
        }
    }

    private GameObject SelectObject()
    {
        if (pointerRenderer.IsVisible() && pointerRenderer.IsValidCollision() && pointerRenderer.GetDestinationHit().collider.CompareTag("SelectableObjects"))
        {
            GameObject selected = pointerRenderer.GetDestinationHit().collider.gameObject;
            Destroy(selected);
            return selected;
        }
        return null;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (pointerRenderer.IsVisible() && pointerRenderer.IsValidCollision() && pointerRenderer.GetDestinationHit().collider.CompareTag("SelectableObjects"))
        {
            pointerRenderer.validCollisionColor = Color.blue;

        }
        else if (pointerRenderer.IsVisible() && pointerRenderer.IsValidCollision() && !pointerRenderer.GetDestinationHit().collider.CompareTag("SelectableObjects"))
        {
            pointerRenderer.validCollisionColor = Color.green;
        }
        
        
    }
}
