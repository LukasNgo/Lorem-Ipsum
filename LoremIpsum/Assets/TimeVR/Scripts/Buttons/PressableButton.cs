using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Behaviour for a physics-based button
/// (C) Peloozoid Labs 2018
/// </summary>
public class PressableButton : LevelRequirement
{
    [SerializeField]
    private bool oneUse = true;
    [SerializeField]
    private float maxMovement;
    [SerializeField]
    private Rigidbody selfRigidbody;
    [SerializeField]
    private Material defaultMaterial;
    [SerializeField]
    private Material pressMaterial;
    [SerializeField]
    private Material disabledMaterial;
    [SerializeField]
    private Renderer selfRenderer;
    [SerializeField]
    private UnityEvent pressEvent;
    
    private Vector3 maxDownPosition;
    private Vector3 startPosition;
    private bool used = false;
    private ButtonState lastButtonState = ButtonState.Up;
    private float lastTimePressed = float.NegativeInfinity;

    //REMINDER! Rigid body x/z constraints must be enabled
    //This stops unnatural physics behaviour when the button is interacted with in VR (eg. lateral motion)
    
    void Start ()
    {
        startPosition = transform.position;
        maxDownPosition = transform.position + (-transform.up * maxMovement); //relative down position
        selfRenderer.material = defaultMaterial;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position.y < maxDownPosition.y)
        {
            transform.position = maxDownPosition;
            ClearPhysicsForces();
            if (pressEvent != null && lastButtonState == ButtonState.Up) //stop double/triple etc presses on reusable button
            {
                if (ButtonActive())
                {
                    used = true;
                    pressEvent.Invoke(); //Do thing
                    lastTimePressed = Time.time;
                    StartCoroutine(ButtonPressFlash(pressMaterial));
                }
                else
                {
                    StartCoroutine(ButtonPressFlash(disabledMaterial));
                }
            }
            lastButtonState = ButtonState.Down;
        }
        else if(transform.position.y > startPosition.y)
        {
            transform.position = startPosition;
            ClearPhysicsForces();
            lastButtonState = ButtonState.Up;
        }
	}

    private IEnumerator ButtonPressFlash(Material material)
    {
        Material startMaterial = selfRenderer.material;
        selfRenderer.material = material;
        float timer = 0;
        while (timer < 0.25f)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        selfRenderer.material = startMaterial;
    }

    private void ClearPhysicsForces()
    {
        selfRigidbody.velocity = Vector3.zero;
        selfRigidbody.angularVelocity = Vector3.zero;
    }

    private bool ButtonActive()
    {
        //Note: IsComplete() (i.e a potential level requirement) indirectly relies on this value, edit with caution
        return !(oneUse && used); //should that not be || ?
    }

    /// <summary>
    /// Has the button been pressed?
    /// </summary>
    /// <returns>True if the button was pressed in the last 2 seconds</returns>
    public override bool IsComplete()
    {
        return (Time.time - lastTimePressed) < 2.0f;
    }
}
