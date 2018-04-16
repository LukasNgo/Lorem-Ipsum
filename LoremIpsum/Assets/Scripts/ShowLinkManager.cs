using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLinkManager : MonoBehaviour {

    public GameObject showLinkPrefab;

    public List<GameObject> m_listOfLinks = new List<GameObject>();

    public void AddLink(GameObject _first, GameObject _second)
    {
        GameObject newLink = Instantiate(showLinkPrefab);

        newLink.GetComponent<ShowLink>().SetLink(_first, _second);

        m_listOfLinks.Add(newLink);
    }

    public void RemoveMe(GameObject _me)
    {
        m_listOfLinks.Remove(_me);
    }

    public void ResetIfLinked(GameObject _me)
    {
        GameObject link = null;
        //GameObject notMe = null;

            Debug.Log(m_listOfLinks.Count);
        for (int i= 0; i < m_listOfLinks.Count; i++)
        {
            if (m_listOfLinks[i] != null)
            {
                if (_me == m_listOfLinks[i].GetComponent<ShowLink>().firstObject)
                {
                    link = m_listOfLinks[i];
                    //notMe = m_listOfLinks[i].GetComponent<ShowLink>().secondObject;
                }
                else if (_me == m_listOfLinks[i].GetComponent<ShowLink>().secondObject)
                {
                    link = m_listOfLinks[i];
                    //notMe = m_listOfLinks[i].GetComponent<ShowLink>().firstObject;
                }
            }
        }

        if (link != null)
        {
            link.GetComponent<ShowLink>().UnlinkObjects();
            //GetComponent<ResetLink>().resetObject(notMe);
        }
        
    }
}
