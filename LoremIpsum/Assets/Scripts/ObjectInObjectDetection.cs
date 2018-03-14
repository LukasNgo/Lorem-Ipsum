using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInObjectDetection : MonoBehaviour {

    public PlaceObjects placeObject;
    public float timer = 0.3f;

    private bool m_clip = false;

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.gameObject.tag == placeObject.objectTag)
            {
                placeObject.canPlace = false;

                StartCoroutine(Clipping());
            }
            else if (m_clip == false)
            {
                placeObject.canPlace = true;
            }
        }
        catch(NullReferenceException ex)
        {
            Debug.Log("NullReferenceException in Object Detection");
        }
    }

    private IEnumerator Clipping()
    {
        m_clip = true;

        yield return new WaitForSeconds(timer);

        m_clip = false;
    }

}
