using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectsToString : MonoBehaviour {

    public GameObject[] objectsToSave;
    public List<string> returnString;

    public List<string> ConvertGameObjects(){

        returnString.Clear();

		objectsToSave = GameObject.FindGameObjectsWithTag("SelectableObjects");

        if (objectsToSave != null)
        {
            foreach (GameObject saveObject in objectsToSave)
            {
                returnString.Add(saveObject.ToString());      //object's name
                Vector3 _tempVector = saveObject.transform.position;
                returnString.Add(_tempVector.ToString("G4"));     //object's position
                returnString.Add(saveObject.transform.rotation.ToString("G4"));       //object's rotation
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
