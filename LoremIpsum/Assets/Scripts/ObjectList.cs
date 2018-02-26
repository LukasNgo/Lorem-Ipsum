using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour {

    [SerializeField]
    private GameObject[] objectArray = new GameObject[5];

    public GameObject[] getObjectArray()
    {
        return objectArray;
    }

}
