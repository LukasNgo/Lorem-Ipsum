using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class ChangeModes : MonoBehaviour {

    public ControllerManager RC;
    public ControllerManager LC;

    public void ChangeToPlayerMode()
    {
        RC.ChangeMode("Player");
        LC.ChangeMode("Player");
    }

    public void ChangeToBuildMode()
    {
        RC.ChangeMode("Build");
        LC.ChangeMode("Build");
    }

    public void ChangeToLinkMode()
    {
        RC.ChangeMode("Link");
        LC.ChangeMode("Link");
    }

}
