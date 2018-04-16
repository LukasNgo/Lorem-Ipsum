using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLink : MonoBehaviour {

    public LineRenderer myLine;
    public ShowLinkManager myManager;

    public GameObject m_firstObject;
    public GameObject m_secondObject;

    public void SetLink(GameObject _first, GameObject _second)
    {
        m_firstObject = _first;
        m_secondObject = _second;

        myLine.SetPosition(0, m_firstObject.transform.position);
        myLine.SetPosition(1, m_secondObject.transform.position);
    }

    private void Update()
    {
        if ((m_firstObject == null) || (m_secondObject == null))
        {
            myManager.RemoveMe(gameObject);
        }
        else if ((m_firstObject.activeSelf == false) || (m_secondObject.activeSelf == false))
        {
            gameObject.SetActive(false);
        }
        else if ((m_firstObject.activeSelf == true) && (m_secondObject.activeSelf == true))
        {
            gameObject.SetActive(true);
        }

        myLine.SetPosition(0, m_firstObject.transform.position);
        myLine.SetPosition(1, m_secondObject.transform.position);

    }
}
