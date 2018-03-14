using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class RotateObject : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;

    private float y = 0.0f;
    private float x = 0.0f;
    private Vector2 axis = new Vector2(0.0f, 0.0f);

    public float deadZone = 0.3f;
    public float changeSpeed = 10.0f;

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
        if (!((axis.y == 0.0f) && (axis.x == 0.0f)))
        {
            UpdateAngles();
        }
    }

    private void UpdateAngles()
    {
        if ((axis.y > deadZone) || (axis.y < -deadZone))
        {
            y = y + (axis.y * changeSpeed * Time.deltaTime);
        }

        if ((axis.x > deadZone) || (axis.x < -deadZone))
        {
            x = x + (axis.x * changeSpeed * Time.deltaTime);
        }

        if (y > 360)
        {
            y = y - 360;
        }
        else if (y < 0)
        {
            y = y + 360;
        }

        if (x > 360)
        {
            x = x - 360;
        }
        else if (x < 0)
        {
            x = x + 360;
        }

        Quaternion placeRotation = Quaternion.Euler(x, y, 0);
        GetComponent<PlaceObjects>().placeRotation = placeRotation;
    }
}
