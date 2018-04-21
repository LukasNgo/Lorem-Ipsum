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

    public float deadZone = 0.3f;
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
        if ((!((axis.y == 0.0f) && (axis.x == 0.0f))) && (onCooldown == false))
        {
            StartCoroutine("UpdateAngles");
        }
    }

    IEnumerator UpdateAngles()
    {
        onCooldown = true;

        rotationLimitX = rotationRules.rotationLimitX;
        rotationLimitY = rotationRules.rotationLimitY;

        if ((axis.y > deadZone) || (axis.y < -deadZone))
        {
            rotationNumY = rotationNumY + 1;
        }

        if ((axis.x > deadZone) || (axis.x < -deadZone))
        {
            rotationNumX = rotationNumX + 1;
        }

        if (rotationNumY > rotationLimitY)
        {
            rotationNumY = rotationNumY - rotationLimitY;
        }
        else if (rotationNumY < rotationLimitY)
        {
            rotationNumY = rotationNumY + rotationLimitY;
        }

        if (rotationNumX > rotationLimitX)
        {
            rotationNumX = rotationNumX - rotationLimitX;
        }
        else if (rotationNumX < rotationLimitX)
        {
            rotationNumX = rotationNumX + rotationLimitX;
        }

        yield return new WaitForSeconds(rotationCooldown);

        Quaternion placeRotation = Quaternion.Euler(rotationNumX, rotationLimitY, 0);
        placeObjects.placeRotation = placeRotation;

        onCooldown = false;
    }
}
