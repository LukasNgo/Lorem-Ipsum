using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class ObjectInfo : MonoBehaviour
{
    [Tooltip("insert controller with pointer renderer component on it")]
    [SerializeField]
    private VRTK_BasePointerRenderer pointerRenderer;
    [Tooltip("insert object info UI from the hierarchy")]
    [SerializeField]
    private GameObject objectInfoUI;
    [Tooltip("Insert text component from the object info UI")]
    [SerializeField]
    private Text objectInfoText;

    private GameObject selectedObject = null;

    private void Update ()
    {
        if (pointerRenderer.IsVisible())
        {
            if (pointerRenderer.IsValidCollision() && pointerRenderer.GetDestinationHit().collider.CompareTag("SelectableObjects"))
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
