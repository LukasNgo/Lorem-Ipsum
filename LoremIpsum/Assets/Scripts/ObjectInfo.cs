using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class ObjectInfo : MonoBehaviour
{
    [SerializeField]
    private VRTK_BasePointerRenderer pointerRenderer;
    [SerializeField]
    private GameObject objectInfoUI;
    [SerializeField]
    private Text objectInfoText;

    private GameObject selectedObject = null;

    private void Update ()
    {
        if (pointerRenderer.IsVisible() && pointerRenderer.IsValidCollision() && pointerRenderer.GetDestinationHit().collider.CompareTag("SelectableObjects"))
        {
            selectedObject = pointerRenderer.GetDestinationHit().collider.gameObject;
            objectInfoUI.SetActive(true);
            ShowInfo();
        }
        else
        {
            selectedObject = null;
            objectInfoUI.SetActive(false);
        }
    }

    private void ShowInfo()
    {
        if (selectedObject != null)
        {
            objectInfoText.text = selectedObject.GetComponent<SetObjectInfo>().GetName() + "\n\n" + 
                selectedObject.GetComponent<SetObjectInfo>().GetInfo();
        }
        else
        {
            objectInfoText.text = "";
        }
    }
}
