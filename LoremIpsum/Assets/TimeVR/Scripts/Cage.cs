using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The behaviour for the Cage
/// (C) Peloozoid Labs 2018
/// </summary>
public class Cage : MonoBehaviour
{
    /// <summary>
    /// Scales the cage into appearing
    /// </summary>
    public void Appear()
    {
        transform.localScale = new Vector3(1, 0.975f, 1);
    }

    /// <summary>
    /// Scales the cage into disappearing
    /// </summary>
    public void Disappear()
    {
        transform.localScale = new Vector3(1, 0.01f, 1);
    }
}
