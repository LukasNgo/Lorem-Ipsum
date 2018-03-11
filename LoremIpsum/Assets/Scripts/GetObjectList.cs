using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjectList : MonoBehaviour {

    private ObjectList objectListScript;

    private GameObject[] m_objectListArray;

	// Use this for initialization
	void Start () {
        objectListScript = GameObject.Find("insertObjects").GetComponent<ObjectList>();

        m_objectListArray = objectListScript.getObjectArray();

        foreach (GameObject i in m_objectListArray)
        {
            //Debug.Log(i);
        }
	}
	
	
}
