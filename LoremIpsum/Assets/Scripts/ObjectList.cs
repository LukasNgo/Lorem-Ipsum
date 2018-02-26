using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour {

    [SerializeField]
    private GameObject[] objectArray = new GameObject[10];

    public GameObject[] getObjectArray()
    {
        return objectArray;
    }

}
