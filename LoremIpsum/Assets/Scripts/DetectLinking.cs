using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;

public class DetectLinking : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;
    public VRTK_BasePointerRenderer pointerRenderer;

    public GameObject wantToLinkMenu;
    public GameObject canLinkResultMenu;
    public Text canLinkTextResult;

    public ShowLinkManager showLinkManager;
    public string objectString = "SelectableObjects";

    private GameObject firstObject = null;
    private GameObject secondObject = null;

    private bool selectingFirst = true;

    public LinkObjects linkObjects_script;

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
        if (pointerRenderer.GetDestinationHit().collider.gameObject.tag == objectString)
        {

            if (selectingFirst == true)
            {
                firstObject = pointerRenderer.GetDestinationHit().collider.gameObject;
                selectingFirst = false;
            }
            else if (pointerRenderer.GetDestinationHit().collider.gameObject != firstObject)
            {
                secondObject = pointerRenderer.GetDestinationHit().collider.gameObject;
                wantToLinkMenu.SetActive(true);
            }

        }

    }

    public void ResetLink()
    {
        selectingFirst = true;
        firstObject = null;
        secondObject = null;
    }

    public void CheckLinkIsValid()//Selected on wantToLinkMenu button "YES"
    {
        int firstID = firstObject.GetComponent<ObjectLinkRules>().linkID;
        bool valid = secondObject.GetComponent<ObjectLinkRules>().CanBeLinkedToID(firstID);

        if (valid == true)
        {
            //Send Link information to link objects script
            showLinkManager.ResetIfLinked(firstObject);
            showLinkManager.ResetIfLinked(secondObject);
            linkObjects_script.GetComponent<LinkObjects>().setLinkedObjects(firstObject, secondObject);
            showLinkManager.AddLink(firstObject, secondObject);

            canLinkTextResult.text = "Valid Link";
        }
        else
        {
            canLinkTextResult.text = "Non-Valid Link";
        }

        canLinkResultMenu.SetActive(true);
        ResetLink();
    }

}
