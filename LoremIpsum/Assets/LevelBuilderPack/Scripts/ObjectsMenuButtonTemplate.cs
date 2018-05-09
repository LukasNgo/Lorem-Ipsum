using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsMenuButtonTemplate : MonoBehaviour {

    [SerializeField]
    private Text myText;
    [SerializeField]
    private ObjectsMenuButtonControl buttonControl;

    private GameObject myButtonObject;

    public void SetText(string textString)
    {
        myText.text = textString;

        this.gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void SetObject(GameObject buttonObject)
    {
        myButtonObject = buttonObject;
    }

    public void OnClick()
    {
        buttonControl.ButtonClicked(myButtonObject);
    }

}
