using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface describing an object which can be queried to determine if a level can be considered completed
/// (C) Peloozoid Labs 2018
/// </summary>
public interface ILevelRequirement
{
    bool IsComplete();
}
