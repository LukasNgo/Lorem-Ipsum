using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsRotations : MonoBehaviour {

    public float[] possibleRotationsX;
    public float[] possibleRotationsY;

    public int rotationLimitX;
    public int rotationLimitY;

    private void Start()
    {
        rotationLimitX = possibleRotationsX.Length;
        rotationLimitY = possibleRotationsY.Length;
    }

    public Quaternion GetRotation(int x, int y)
    {
        Quaternion rotation = Quaternion.Euler(x, y, 0);
        return rotation;
    }
}
