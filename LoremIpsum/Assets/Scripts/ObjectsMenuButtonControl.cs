using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMenuButtonControl : MonoBehaviour {

    [SerializeField]
    private GameObject buttonTemplate, menu;

    private ObjectList m_objectListScript;
    private GameObject[] m_objectListArray;
    private PlaceObjects m_placeObjects_script;
    private GameObject m_selected;

    private void Start()
    {
        m_placeObjects_script = GameObject.Find("B_RightController").GetComponent<PlaceObjects>();

        m_objectListScript = GameObject.Find("insertObjects").GetComponent<ObjectList>();
    
        m_objectListArray = m_objectListScript.getObjectArray();
    
        foreach (GameObject i in m_objectListArray)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
    
            button.GetComponent<ObjectsMenuButtonTemplate>().SetText(i.name);
    
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
