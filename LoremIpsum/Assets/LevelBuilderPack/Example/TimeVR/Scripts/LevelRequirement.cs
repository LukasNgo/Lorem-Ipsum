using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Objects that can be queried to determine if a level is complete
/// (C) Peloozoid Labs 2018
/// </summary>
public class LevelRequirement : MonoBehaviour, ILevelRequirement
{
    /// <summary>
    /// Has the requirement been completed?
    /// </summary>
    /// <returns>True if the requirement is complete, false otherwise</returns>
    public virtual bool IsComplete()
    {
        Debug.LogWarning("ILevelRequirement default implementation being used");
        return false;
    }
}
