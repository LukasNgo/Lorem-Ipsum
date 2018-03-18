using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectInfo : MonoBehaviour {

    [SerializeField]
    private string ObjectName, ObjectInfo;

    public string GetName()
    {
        return ObjectName;
    }
    public string GetInfo()
    {
        return ObjectInfo;
    }
}
