using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlaceObjects : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;
    public VRTK_BasePointerRenderer pointerRenderer;

    public GameObject SelectedObject = null;//Change to private later
    private GameObject ShowVerison;
    private Vector3 placeLocation;

    private void Start()
    {
        ShowVerison = Instantiate(SelectedObject, transform);

        ShowVerison.GetComponent<Collider>().enabled = false;
        for (int i = 0; i < ShowVerison.GetComponentsInChildren<Collider>().Length; i++)
        {
            ShowVerison.GetComponentsInChildren<Collider>()[i].enabled = false;
        }
        //comment out later as it should start out null
    }

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
        if ((SelectedObject != null) && (pointerRenderer.IsVisible() == true) && (pointerRenderer.IsValidCollision() == true))
        {
            PlaceObject();
        }
    }

    //Below are the meaty scripts

    private void PlaceObject()
    {
        Instantiate(SelectedObject, placeLocation, Quaternion.identity);//Replace Instantiate with an object pool
    }

    private void Update()
    {
        placeLocation = pointerRenderer.GetDestinationHit().point;

        if ((pointerRenderer.IsVisible() == true) && (SelectedObject != null) && (pointerRenderer.IsValidCollision() == true))
        {
            ShowVerison.SetActive(true);
            ShowVerison.transform.position = placeLocation;
            ShowVerison.GetComponent<Renderer>().material.color = pointerRenderer.validCollisionColor;
        }
        else
        {
            ShowVerison.SetActive(false);
        }
    }

    //Used to changed the gameobject selected
    public void ChangeSelectedObject(GameObject newObject)
    {
        SelectedObject = newObject;

        if (SelectedObject != null)
        {
            ShowVerison = Instantiate(SelectedObject, placeLocation, Quaternion.identity);
            ShowVerison.GetComponent<Collider>().enabled = false;

            for (int i = 0; i < ShowVerison.GetComponentsInChildren<Collider>().Length; i++)
            {
                ShowVerison.GetComponentsInChildren<Collider>()[i].enabled = false;
            }
        }
    }
}
