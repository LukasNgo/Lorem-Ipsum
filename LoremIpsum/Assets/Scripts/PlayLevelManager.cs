using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevelManager : MonoBehaviour {

    private StartArea m_start = null;
    private FinishArea m_finish = null;

    public MenuToggle menu;
    public GameObject failedPlay;
    public GameObject winGame;

    public GameObject player;

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

            m_start.myManager = this;
            m_finish.myManager = this;

            player.transform.position = new Vector3(m_start.transform.position.x, 0, m_start.transform.position.z);
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
        menu.ChangeMenuToPlaying(false);

        m_start = null;
        m_finish = null;
    }
}
