using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SelectPlacedItem : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;
    public VRTK_BasePointerRenderer pointerRenderer;

    private GameObject m_selected;

    private void OnEnable()
    { 
        controllerEvents.TriggerReleased += controllerEvents_TriggerReleased;
    }

    private void OnDisable()
    {
        controllerEvents.TriggerReleased -= controllerEvents_TriggerReleased;
    }

    private void controllerEvents_TriggerReleased(object sender, ControllerInteractionEventArgs e)
    {
        SelectObject();

    }

    public void SelectObject()
    {
        if (pointerRenderer.IsVisible() && pointerRenderer.IsValidCollision() && pointerRenderer.GetDestinationHit().collider.CompareTag("SelectableObjects"))
        {
            m_selected = pointerRenderer.GetDestinationHit().collider.gameObject;           
        }
    }

    // Use this for initialization
    void Start () {
		
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
