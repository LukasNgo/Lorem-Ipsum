using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectTimer : MonoBehaviour {

    public PlaceObjects placeObjects;

    public void openMenu()
    {
        placeObjects.canPlace = false;
    }

    public void closeMenu()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        placeObjects.canPlace = true;
    }
}
