using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ResetLink : MonoBehaviour {

    private Transform m_transform;

    private GameObject gameobjectToInstantiate = null;

    private ObjectList m_objectList_script;
    private GameObject[] objectArray = null;


    private void Start()
    {
        m_objectList_script = GameObject.Find("insertObjects").GetComponent<ObjectList>();
        objectArray = m_objectList_script.getObjectArray();
    }

    public void resetObject(GameObject objectToReset)
    {
        
        string toSpilt = objectToReset.name;
        string[] splitResult = toSpilt.Split(new char[] { ' ', '(' });

        Debug.Log("Searching for: " + splitResult[0]);

        for (int i = 0; i < objectArray.Length; i++)
        {
            if (objectArray[i].name == splitResult[0])
            {
                m_transform = objectToReset.transform;
                Destroy(objectToReset);

                GameObject exists = null;
                Debug.Log("objectInArray selected: " + objectArray[i]);
                exists = Instantiate(objectArray[i], m_transform.position, m_transform.rotation) as GameObject;
                Debug.Log("Object is assigned exists: " + exists);
                if (exists != null)
                {
                    exists.SetActive(true);

                    Debug.Log("Instantiated");
                }
                else
                {
                    Debug.Log("FAILED");
                }
            }
            else
            {
                Debug.Log("Object does not exist in list");
            }
        }
        
    }
}
