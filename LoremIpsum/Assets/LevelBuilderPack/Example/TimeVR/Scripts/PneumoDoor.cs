using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (C) Peloozoid Labs 2018
/// </summary>
public class PneumoDoor : MonoBehaviour
{
    private JointMotor motor;
    private HingeJoint hinge;
    private Coroutine transporter;
    private IPneumoActivate pneumoObject;
    private GameObject insertedObject;
    private bool loadableCannister, doorClosed;
    private bool buttonPressed;

    // Use this for initialization
    void Start () {
        hinge = gameObject.GetComponent<HingeJoint>();
        motor = hinge.motor;
        loadableCannister = false;
        doorClosed = true;
        buttonPressed = false;

        Debug.Log("Some bugged Script in PneumoDoor.cs commented out");
    }
	
	// Update is called once per frame
	void Update () {
        if((transform.rotation.eulerAngles.x <= 271 && transform.rotation.eulerAngles.x >= 269) && loadableCannister == true)
        {
            if (transporter == null)
            {
                pneumoObject = insertedObject.GetComponent<IPneumoActivate>();
                if (pneumoObject != null)
                {
                    pneumoObject.PneumoActivate();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        insertedObject = other.gameObject;
        //if(other.GetComponent<LevelCannister>() != null)
        //{
        //    loadableCannister = true;
        //}
    }

    public void ButtonPressed()
    {
        if (doorClosed != true)
        {
            motor.targetVelocity = -40;
            hinge.motor = motor;
            doorClosed = true;
            
        }
        else
        {
            motor.targetVelocity = 40;
            hinge.motor = motor;
            doorClosed = false;
        }
    }
}
