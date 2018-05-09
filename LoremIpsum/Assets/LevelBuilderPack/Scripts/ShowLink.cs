using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLink : MonoBehaviour {

    public LineRenderer myLine;
    public ShowLinkManager myManager;

    public GameObject firstObject;
    public GameObject secondObject;

    public void SetLink(GameObject _first, GameObject _second)
    {
        firstObject = _first;
        secondObject = _second;

        myLine.SetPosition(0, firstObject.transform.position);
        myLine.SetPosition(1, secondObject.transform.position);
    }

    private void Update()
    {
        if ((firstObject == null) || (secondObject == null))
        {
            myManager.RemoveMe(gameObject);
        }
        else if ((firstObject.activeSelf == false) || (secondObject.activeSelf == false))
        {
            gameObject.SetActive(false);
        }
        else if ((firstObject.activeSelf == true) && (secondObject.activeSelf == true))
        {
            gameObject.SetActive(true);
        }

        if (firstObject != null && secondObject != null)
        {
            myLine.SetPosition(0, firstObject.transform.position);
            myLine.SetPosition(1, secondObject.transform.position);
        }
    }

    public void UnlinkObjects()
    {
        myManager.RemoveMe(gameObject);
        Destroy(gameObject);
        Debug.Log("Unlinking Objects");
    }

}
