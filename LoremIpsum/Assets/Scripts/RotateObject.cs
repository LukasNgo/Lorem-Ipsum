using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class RotateObject : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;

    private float y = 0.0f;
    private float x = 0.0f;

    public float changeSpeed = 5.0f;

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
        Vector2 Axis = controllerEvents.GetTouchpadAxis();

        y = y + (Axis.y * changeSpeed);
        x = x + (Axis.x * changeSpeed);

        updateAngles();
    }

    private void updateAngles()
    {
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

        Debug.Log("x: " + x + " / y: " + y);

        GetComponent<PlaceObjects>().rotation = new Vector2(x, y);
    }
}
