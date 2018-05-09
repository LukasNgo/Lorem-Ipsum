using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class ControllerManager : MonoBehaviour {

    public string controllerMode = "Player";
    public bool right = false;
    public MenuToggle inGameMenu;

    public MonoBehaviour[] playerScripts;
    public MonoBehaviour[] buildScripts;
    public MonoBehaviour[] linkScripts;

    [SerializeField]
    private float m_waitTime = 3.0f;

    public void ChangeMode(string mode)
    {
        controllerMode = mode;

        UpdateControllerMode();
    }

    public void UpdateControllerMode()
    {

        switch (controllerMode)
        {
            case "Player":
                changeScripts(buildScripts, false);
                changeScripts(linkScripts, false);
                changeScripts(playerScripts, true);

                inGameMenu.PlayerMode = true;
                inGameMenu.BuildMode = false;

                GetComponent<VRTK_Pointer>().enableTeleport = false;
                StartCoroutine(pauseTeleport());
                GetComponent<VRTK_InteractGrab>().enabled = true;

                break;

            case "Build":
                changeScripts(playerScripts, false);
                changeScripts(linkScripts, false);
                changeScripts(buildScripts, true);

                inGameMenu.PlayerMode = false;
                inGameMenu.BuildMode = true;

                GetComponent<VRTK_Pointer>().enableTeleport = false;
                GetComponent<VRTK_InteractGrab>().enabled = false;
                break;

            case "Link":
                changeScripts(buildScripts, false);
                changeScripts(playerScripts, false);
                changeScripts(linkScripts, true);

                inGameMenu.PlayerMode = false;
                inGameMenu.BuildMode = false;

                GetComponent<VRTK_Pointer>().enableTeleport = false;
                GetComponent<VRTK_InteractGrab>().enabled = false;

                Debug.Log("In Link Mode");
                break;
        }

        inGameMenu.ChangeMenuColors();

    }

    private IEnumerator pauseTeleport()
    {
        yield return new WaitForSeconds(m_waitTime);
        GetComponent<VRTK_Pointer>().enableTeleport = true;
    }

    private void changeScripts(MonoBehaviour[] scripts, bool enabled)
    {
        for (int i = 0; i < scripts.Length; i++)
        {
            scripts[i].enabled = enabled;
        }
    }

}
