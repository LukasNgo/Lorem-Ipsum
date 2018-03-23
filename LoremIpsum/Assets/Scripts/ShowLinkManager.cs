using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLinkManager : MonoBehaviour {

    public GameObject showLinkPrefab;

    private List<GameObject> m_listOfLinks;

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
}
