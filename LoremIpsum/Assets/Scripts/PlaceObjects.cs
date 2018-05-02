using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlaceObjects : MonoBehaviour
{
    public GameObject objectsMenu;
    public GameObject saveMenu;
    public GameObject loadMenu;
    public GameObject overwriteMenu;

    public VRTK_ControllerEvents controllerEvents;
    public VRTK_BasePointerRenderer pointerRenderer;

    public string objectTag = "SelectableObjects";

    public GameObject SelectedObject = null;//Change to private later
    private GameObject ShowVerison;
    private Vector3 placeLocation;

    public Quaternion placeRotation;

    private bool menu = true;

    public bool canPlace = true;

    private void Start()
    {
        ShowVerison = Instantiate(SelectedObject, placeLocation, placeRotation);

        DisableColliders();
        //comment out later as it should start out null
    }

    private void DisableColliders()
    {
        for (int i = 0; i < ShowVerison.GetComponentsInChildren<Collider>().Length; i++)
        {
            ShowVerison.GetComponentsInChildren<Collider>()[i].isTrigger = true;

            ShowVerison.GetComponentsInChildren<Collider>()[i].gameObject.AddComponent<ObjectInObjectDetection>();
            ShowVerison.GetComponentsInChildren<ObjectInObjectDetection>()[i].placeObject = this;

            ShowVerison.GetComponentsInChildren<Collider>()[i].gameObject.layer = 2;
        }

        for (int i = 0; i < ShowVerison.GetComponentsInChildren<MeshCollider>().Length; i++)
        {
            ShowVerison.GetComponentsInChildren<MeshCollider>()[i].convex = true;
            ShowVerison.GetComponentsInChildren<MeshCollider>()[i].isTrigger = true;

            ShowVerison.GetComponentsInChildren<MeshCollider>()[i].gameObject.AddComponent<ObjectInObjectDetection>();
            ShowVerison.GetComponentsInChildren<ObjectInObjectDetection>()[i].placeObject = this;

            ShowVerison.GetComponentsInChildren<MeshCollider>()[i].gameObject.layer = 2;
        }
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
        if ((SelectedObject != null) && (pointerRenderer.IsVisible() == true) && (pointerRenderer.IsValidCollision() == true) && (menu == false) && (canPlace == true))
        {
            PlaceObject();
        }
    }

    //Below are the meaty scripts

    private void PlaceObject()
    {
        GameObject newItem = Instantiate(SelectedObject, placeLocation, placeRotation);//Replace Instantiate with an object pool
        newItem.SetActive(true);
    }

    private void Update()
    {
        if (SelectedObject != null && !objectsMenu.activeInHierarchy && !saveMenu.activeInHierarchy && !loadMenu.activeInHierarchy && !overwriteMenu.activeInHierarchy)
        {
            placeLocation = pointerRenderer.GetDestinationHit().point;

            if ((pointerRenderer.IsVisible() == true) && (pointerRenderer.IsValidCollision() == true) && (menu == false) && (ShowVerison != null))
            {
                ShowVerison.SetActive(true);
                ShowVerison.transform.position = placeLocation;
                ShowVerison.transform.rotation = placeRotation;

                Vector3 tempVector = ShowVerison.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);

                ShowVerison.transform.position = tempVector;
                placeLocation = ShowVerison.transform.position;

                if (canPlace == true)
                {
                    ShowVerison.GetComponent<Renderer>().material.color = pointerRenderer.validCollisionColor;
                }
                else
                {
                    ShowVerison.GetComponent<Renderer>().material.color = pointerRenderer.invalidCollisionColor;
                }
            }
            else if (ShowVerison != null)
            {
                ShowVerison.SetActive(false);
            }
        }
    }

    //Used to changed the gameobject selected
    public void ChangeSelectedObject(GameObject newObject)
    {


        SelectedObject = newObject;


        if (SelectedObject != null)
        {
            ShowVerison = Instantiate(SelectedObject, placeLocation, placeRotation);
            DisableColliders();
        }
        else if (SelectedObject == null)
        {
            Destroy(ShowVerison);
        }
    }

    public void MenuUp(bool menuIsUp)
    {
        menu = menuIsUp;
    }
}
