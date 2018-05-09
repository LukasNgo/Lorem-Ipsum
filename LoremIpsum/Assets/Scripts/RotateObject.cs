using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class RotateObject : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;
    public ObjectsRotations rotationRules;

    private int rotationNumX = 0;
    private int rotationNumY = 0;

    private int rotationLimitX;
    private int rotationLimitY;

    private Vector2 axis = new Vector2(0.0f, 0.0f);

    public float deadZone = 0.6f;
    public float rotationCooldown = 1.0f;
    private bool onCooldown = false;
    public PlaceObjects placeObjects;

    private void OnEnable()
    {
        controllerEvents.TouchpadAxisChanged += controllerEvents_TouchpadAxisChanged;
    }

    private void OnDisable()
    {
        controllerEvents.TouchpadAxisChanged -= controllerEvents_TouchpadAxisChanged;
    }

    private void controllerEvents_TouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
    {
        axis = controllerEvents.GetTouchpadAxis();
    }

    private void Update()
    {
        if ((!((axis.y == 0.0f) && (axis.x == 0.0f))) && (onCooldown == false) && (rotationRules != null))
        {
            onCooldown = true;
            StartCoroutine(UpdateAngles());
        }
    }

    IEnumerator UpdateAngles()
    {
        rotationLimitX = rotationRules.rotationLimitX;
        rotationLimitY = rotationRules.rotationLimitY;

        if (axis.y > deadZone)
        {
            rotationNumY = rotationNumY + 1;
        }
        else if (axis.y < -deadZone)
        {
            rotationNumY = rotationNumY - 1;
        }

        if (axis.x > deadZone)
        {
            rotationNumX = rotationNumX + 1;
        }
        else if (axis.x < -deadZone)
        {
            rotationNumX = rotationNumX - 1;
        }

        if (rotationNumY >= rotationLimitY)
        {
            rotationNumY = 0;
        }
        else if (rotationNumY < 0)
        {
            rotationNumY = rotationLimitY - 1;
        }

        if (rotationNumX >= rotationLimitX)
        {
            rotationNumX = 0;
        }
        else if (rotationNumX < 0)
        {
            rotationNumX = rotationLimitX - 1;
        }

        Quaternion placeRotation = Quaternion.Euler(0, 0, 0);
        placeRotation = rotationRules.GetRotation(rotationNumX, rotationNumY);

        placeObjects.placeRotation = placeRotation;

        yield return new WaitForSeconds(rotationCooldown);

        onCooldown = false;
    }
}
