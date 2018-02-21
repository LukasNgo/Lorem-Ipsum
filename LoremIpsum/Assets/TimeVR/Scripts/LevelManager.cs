using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages a level's requirements and determines if they have been completed. When complete, success actions are called.
/// (C) Peloozoid Labs 2018
/// </summary>
public class LevelManager : MonoBehaviour
{
    /// <summary>
    /// The requirements for this level
    /// </summary>
    [SerializeField]
    private List<LevelRequirement> requirements;
    /// <summary>
    /// The actions to perform when the requirements are complete
    /// </summary>
    [SerializeField]
    private UnityEvent successActions;
    /// <summary>
    /// The actions to be performed if the requirements were previously met and are no longer to undo level completion
    /// </summary>
    [SerializeField]
    private UnityEvent undoActions;

    private bool completed = false;

    private void Update()
    {
        if (!completed)
        {
            //Checks for completion
            bool complete = CheckComplete();

            if (complete)
            {
                completed = true;
                Debug.Log("LevelManager, success requirements met");
                successActions.Invoke();
            }
        }
        else
        {
            //Keep double checking for failure
            bool stillComplete = CheckComplete();

            if (!stillComplete)
            {
                Debug.Log("Failure after previous success, undoing");
                completed = false;
                if (undoActions != null)
                {
                    undoActions.Invoke();
                }
            }
        }
    }

    /// <summary>
    /// Check the requirements to check if they've all been met
    /// </summary>
    /// <returns>True if all requirements have been met</returns>
    private bool CheckComplete()
    {
        foreach (ILevelRequirement requirement in requirements)
        {
            if (!requirement.IsComplete())
            {
                return false;
            }
        }
        return true;
    }
    
}
