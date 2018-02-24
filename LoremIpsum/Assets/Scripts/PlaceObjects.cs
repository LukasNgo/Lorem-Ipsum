using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlaceObjects : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;
    public VRTK_BasePointerRenderer pointerRenderer;
    public GameObject SelectedObject;

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
        PlaceObject();
    }

    //Below are the meaty scripts

    private void PlaceObject()
    {
        Vector3 placeLocation = pointerRenderer.GetDestinationHit().point;

        Instantiate(SelectedObject, placeLocation, Quaternion.identity);
    }

    private void Update()
    {
        
    }

    //Used to changed the gameobject selected
    public void ChangeSelectedObject(GameObject newObject)
    {
        SelectedObject = newObject;
    }
}
