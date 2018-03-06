using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInObjectDetection : MonoBehaviour {

    public PlaceObjects placeObject;
    public float timer = 0.3f;

    private bool m_clip = false;

    private void OnTriggerEnter(Collider other)
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

    private IEnumerator Clipping()
    {
        m_clip = true;

        yield return new WaitForSeconds(timer);

        m_clip = false;
    }

}
