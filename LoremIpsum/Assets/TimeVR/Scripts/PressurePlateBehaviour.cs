using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The behaviour of pressure plates
/// (C) Peloozoid Labs 2018
/// </summary>
public class PressurePlateBehaviour : LevelRequirement
{
    /// <summary>
    /// The default material of the pressure plate
    /// </summary>
    public Material defaultMaterial;
    /// <summary>
    /// The material that is applied when the plate is pressed
    /// </summary>
    public Material pressMaterial;

    [SerializeField]
    private UnityEvent activatedEvent;
    [SerializeField]
    private UnityEvent deactivatedEvent;

    public Renderer selfRenderer, lightRenderer;
    //public GameObject myLightObject;
    public Light myLight;
    private bool activeLastFrame = false;

    private bool active = false;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0.1f && transform.position.y < 0.5) //deactivated
        {
            active = false;
            selfRenderer.material = defaultMaterial;
            if (lightRenderer != null)
            {
                lightRenderer.material = defaultMaterial;
            }
            if (myLight != null)
            {
                myLight.color = Color.red;
            }
            if (activeLastFrame)
            {
                activeLastFrame = false;
                if (deactivatedEvent != null)
                {
                    deactivatedEvent.Invoke();
                }
            }
        }
        else //activated
        {
            active = true;
            selfRenderer.material = pressMaterial;
            if (lightRenderer != null)
            {
                lightRenderer.material = pressMaterial;
            }
            if (myLight != null)
            {
                myLight.color = Color.green;
            }
            if(!activeLastFrame)
            {
                activeLastFrame = true;
                if(activatedEvent != null)
                {
                    activatedEvent.Invoke();
                }
            }
        }
    }

    /// <summary>
    /// Has this pressure plate been completed?
    /// </summary>
    /// <returns>True if pressed, false otherwise</returns>
    public override bool IsComplete()
    {
        return active;
    }
}
