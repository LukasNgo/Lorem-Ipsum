using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectsToString : MonoBehaviour {

    private GameObject[] m_objectsToSave;
    private List<string> m_returnString;

	public List<string> ConvertGameObjects(){

		m_objectsToSave = GameObject.FindGameObjectsWithTag("SelectableObjects");

        if (m_objectsToSave != null)
        {
            foreach (GameObject saveObject in m_objectsToSave)
            {
                m_returnString.Add(saveObject.ToString());
                Vector3 _tempVector = saveObject.transform.position;
                m_returnString.Add(_tempVector.ToString("G4"));
                m_returnString.Add(saveObject.transform.rotation.ToString("G4"));
            }
        }
        return m_returnString;
	}
}
