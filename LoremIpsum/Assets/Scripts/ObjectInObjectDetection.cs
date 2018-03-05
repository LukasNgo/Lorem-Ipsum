using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInObjectDetection : MonoBehaviour {

    public PlaceObjects placeObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == placeObject.objectTag)
        {
            placeObject.canPlace = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == placeObject.objectTag)
        {
            placeObject.canPlace = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == placeObject.objectTag)
        {
            placeObject.canPlace = true;
        }
    }

}
