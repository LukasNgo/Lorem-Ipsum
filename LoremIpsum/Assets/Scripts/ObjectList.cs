using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour {

    [SerializeField]
    private GameObject[] m_objectArray = new GameObject[5];

    public GameObject[] getObjectArray()
    {
        return m_objectArray;
    }

}
