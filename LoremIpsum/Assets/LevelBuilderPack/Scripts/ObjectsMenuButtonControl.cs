using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMenuButtonControl : MonoBehaviour {

    [Tooltip("insert menu and button template from object menu UI")]
    [SerializeField]
    private GameObject buttonTemplate, menu;

    [Tooltip("insert controller with place object script component on it(P_RightController)")]
    [SerializeField]
    private PlaceObjects m_placeObjects_script;

    private ObjectList m_objectListScript;
    private GameObject[] m_objectListArray;
    private GameObject m_selected;

    private void Start()
    {
        //m_placeObjects_script = GameObject.Find("P_RightController").GetComponent<PlaceObjects>();

        m_objectListScript = GameObject.Find("insertObjects").GetComponent<ObjectList>();
    
        m_objectListArray = m_objectListScript.getObjectArray();
    
        foreach (GameObject i in m_objectListArray)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
    
            button.GetComponent<ObjectsMenuButtonTemplate>().SetText(i.GetComponent<SetObjectInfo>().GetName());
    
            button.GetComponent<ObjectsMenuButtonTemplate>().SetObject(i);
    
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    public void ButtonClicked(GameObject selectedObject)
    {
        m_selected = selectedObject;

        m_placeObjects_script.ChangeSelectedObject(m_selected);

        menu.SetActive(false);
    }
}
