using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLinkRules : MonoBehaviour {

    public int linkID;//Each need to be unique for each prefab

    public int[] linkIDList;
    public bool listCanLinkTo;//Determines if the list is what it can link to, or what it can't link too

    public bool CanBeLinkedToID(int otherID)
    {
        bool canBeLink = !listCanLinkTo;

        if (linkIDList.Length > 0)
        {
            for (int i = 0; i < linkIDList.Length; i++)
            {
                if (listCanLinkTo == true)//List is filled with IDs it can link to
                {
                    if (linkIDList[i] == otherID)//If it finds a match then it can link to it
                    {
                        canBeLink = true;
                    }
                }
                else//List is filled with IDs it can't link to
                {
                    if (linkIDList[i] == otherID)//If it finds a match then it can't link to it
                    {
                        canBeLink = false;
                    }
                }
            }
        }
        else
        {
            canBeLink = false;
        }

        return canBeLink;
    }

}
