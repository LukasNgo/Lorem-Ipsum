using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjectList : MonoBehaviour {

    private ObjectList objectListScript;

    private GameObject[] objectListArray;

	// Use this for initialization
	void Start () {
        objectListScript = GameObject.Find("Objects").GetComponent<ObjectList>();

        objectListArray = objectListScript.getObjectArray();

        foreach (GameObject i in objectListArray)
        {
            Debug.Log(i);
        }
	}
	
	
}
