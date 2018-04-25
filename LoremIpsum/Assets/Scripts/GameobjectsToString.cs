using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectsToString : MonoBehaviour {

    public GameObject[] objectsToSave; //list of all gameobjects
    public GameObject[] links; //list of visual link objects

    public List<string> returnString;

    public string visualLinkTag = "Link";
    public string selectableObjectTag = "SelectableObjects";

    public List<string> ConvertGameObjects(){

        returnString.Clear();

		objectsToSave = GameObject.FindGameObjectsWithTag(selectableObjectTag);
        links = GameObject.FindGameObjectsWithTag(visualLinkTag);

        List<GameObject> doneItems = new List<GameObject>();

        if (links != null)
        {
            for (int i = 0; i < links.Length; i++)
            {
                returnString.Add("Name:" + links[i].GetComponent<ShowLink>().firstObject.ToString());
                returnString.Add("LinkID:" + (i + 1));
                Vector3 _tempVector = links[i].GetComponent<ShowLink>().firstObject.transform.position;
                returnString.Add("Position:" + _tempVector.ToString("G4"));
                returnString.Add("Rotation:" + links[i].GetComponent<ShowLink>().firstObject.transform.rotation.ToString("G4"));
                returnString.Add("Scale:" + links[i].GetComponent<ShowLink>().firstObject.transform.localScale.ToString("G4"));
                doneItems.Add(links[i].GetComponent<ShowLink>().firstObject);

                returnString.Add("Name:" + links[i].GetComponent<ShowLink>().secondObject.ToString());
                returnString.Add("LinkID:" + (i + 1));
                Vector3 _tempVector2 = links[i].GetComponent<ShowLink>().secondObject.transform.position;
                returnString.Add("Position:" + _tempVector2.ToString("G4"));
                returnString.Add("Rotation:" + links[i].GetComponent<ShowLink>().secondObject.transform.rotation.ToString("G4"));
                returnString.Add("Scale:" + links[i].GetComponent<ShowLink>().secondObject.transform.localScale.ToString("G4"));
                doneItems.Add(links[i].GetComponent<ShowLink>().secondObject);
            }
        }

        if (objectsToSave != null)
        {
            foreach (GameObject saveObject in objectsToSave)
            {
                if (saveObject.activeInHierarchy)
                {
                    if (!doneItems.Contains(saveObject))
                    {
                        returnString.Add("Name:" + saveObject.ToString());
                        returnString.Add("LinkID: 0");
                        Vector3 _tempVector = saveObject.transform.position;
                        returnString.Add("Position:" + _tempVector.ToString("G4"));
                        returnString.Add("Rotation:" + saveObject.transform.rotation.ToString("G4"));
                        returnString.Add("Scale:" + saveObject.transform.localScale.ToString("G4"));
                    }
                }
            }
        }
        return returnString;
	}

    public string[] ListToArray()
    {
        int _size = ConvertGameObjects().Count;
        string[] _newFileContent = new string[_size];

        for (int i = 0; i < _size; i++)
        {
            _newFileContent[i] = ConvertGameObjects()[i];
        }
        
        return _newFileContent;
    }
}
