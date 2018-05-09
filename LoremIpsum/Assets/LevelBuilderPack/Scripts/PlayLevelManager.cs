using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlayLevelManager : MonoBehaviour {

    private StartArea m_start = null;
    private FinishArea m_finish = null;

    public MenuToggle menu;
    public GameObject failedPlay;
    public GameObject winGame;

    public VRTK_BasicTeleport teleporter;

    public void PlayLevel()
    {
        bool failed = false;

        m_start = FindObjectOfType<StartArea>();
        m_finish = FindObjectOfType<FinishArea>();

        if ((m_start == null) || (m_finish == null))
        {
            FailedPlayLevel();
            failed = true;
        }

        if (failed == false)
        {
            menu.ChangeMenuToPlaying(true);

            m_start.ObjectOn();
            m_finish.ObjectOn();
            m_start.myManager = this;
            m_finish.myManager = this;

            Vector3 tp = new Vector3(m_start.transform.position.x, 0, m_start.transform.position.z);
            teleporter.ForceTeleport(tp);
        }
    }

    private void FailedPlayLevel()
    {
        failedPlay.SetActive(true);
    }

    public void WinLevel()
    {
        winGame.SetActive(true);
    }

    public void QuitLevel()
    {
        teleporter.enabled = false;
        StartCoroutine(pauseTeleport());

        menu.ChangeMenuToPlaying(false);

        m_start.ObjectOff();
        m_finish.ObjectOff();
        m_start = null;
        m_finish = null;
    }

    private IEnumerator pauseTeleport()
    {
        yield return new WaitForSeconds(2);
        teleporter.enabled = true;
    }
}
