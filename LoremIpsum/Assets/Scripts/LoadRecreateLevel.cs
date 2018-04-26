using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRecreateLevel : MonoBehaviour {

    // file
    private string[] m_fileContent;

    private ObjectList m_objectList_script;
    private GameObject[] objectArray = null;
    private List<KeyValuePair<int, GameObject>> listOfLinkables = new List<KeyValuePair<int, GameObject>>();
    //private LinkObjects linkObjects_script;
    private ShowLinkManager showLinkManager_script;

    private void Start()
    {
        m_objectList_script = GameObject.Find("insertObjects").GetComponent<ObjectList>();
        objectArray = m_objectList_script.getObjectArray();
    }

    public void RecreateLevel(string[] m_fileContent)
    {
        this.m_fileContent = m_fileContent;
        DeleteSceneObjects();
        InstantiateObjects();
        //LinkObjects();
    }

    // delete objects already in scene; ready for loading
    private void DeleteSceneObjects()
    {
        string[] tags =
        {
            "SelectableObjects",
            "VisualLinks"
        };

        foreach (string tag in tags)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject o in objects)
            {
                Destroy(o.gameObject);
            }
        }
    }

    // instantiate objects from text file
    private void InstantiateObjects()
    {
        // check placeable objects list and place that prefab

        for (int i = 0; i < m_fileContent.Length; i++)
        {
            string objectName = null;
            string LinkID = null;
            string position = null;
            string rotation = null;
            string scale = null;

            // position cords
            float x_cord = 0;
            float y_cord = 0;
            float z_cord = 0;

            // rotation cords
            float rot_x_cord = 0;
            float rot_y_cord = 0;
            float rot_z_cord = 0;
            float rot_w_cord = 0;

            // scale cords
            float scl_x_cord = 0;
            float scl_y_cord = 0;
            float scl_z_cord = 0;

            if (m_fileContent[i].Contains("Name:"))
            {
                objectName = m_fileContent[i].Substring(m_fileContent[i].IndexOf(":") + 1);
                objectName = m_fileContent[i].Substring(0, m_fileContent[i].IndexOf(" ") - 1);
                objectName = m_fileContent[i].Substring(0, m_fileContent[i].IndexOf("(") - 1);
            }

            else if (m_fileContent[i].Contains("LinkID:"))
            {               
                LinkID = m_fileContent[i].Substring(m_fileContent[i].IndexOf(":") + 1);
            }

            else if (m_fileContent[i].Contains("Position:"))
            {                
                position = m_fileContent[i].Substring(m_fileContent[i].IndexOf("(") + 1);
                position = m_fileContent[i].Substring(0, m_fileContent[i].IndexOf(")") - 1);

                string[] positionArray = position.Split(',');

                foreach (string p in positionArray)
                {
                    p.Trim();
                }

                x_cord = float.Parse(positionArray[0]);
                y_cord = float.Parse(positionArray[1]);
                z_cord = float.Parse(positionArray[2]);

            }

            else if (m_fileContent[i].Contains("Rotation:"))
            {               
                rotation = m_fileContent[i].Substring(m_fileContent[i].IndexOf("(") + 1);
                rotation = m_fileContent[i].Substring(0, m_fileContent[i].IndexOf(")") - 1);

                string[] rotationArray = rotation.Split(',');
                
                foreach (string r in rotationArray)
                {
                    r.Trim();
                }

                rot_x_cord = float.Parse(rotationArray[0]);
                rot_y_cord = float.Parse(rotationArray[1]);
                rot_z_cord = float.Parse(rotationArray[2]);
                rot_w_cord = float.Parse(rotationArray[3]);
            }

            else if (m_fileContent[i].Contains("Scale:"))
            {
                scale = m_fileContent[i].Substring(m_fileContent[i].IndexOf("(") + 1);
                scale = m_fileContent[i].Substring(0, m_fileContent[i].IndexOf(")") - 1);

                string[] scaleArray = scale.Split(',');

                foreach (string s in scaleArray)
                {
                    s.Trim();
                }

                scl_x_cord = float.Parse(scaleArray[0]);
                scl_y_cord = float.Parse(scaleArray[1]);
                scl_z_cord = float.Parse(scaleArray[2]);
            }

            // check name against placeable objects list

            int linkID = int.Parse(LinkID);
            Vector3 pos = new Vector3(x_cord, y_cord, z_cord);
            Quaternion rot = Quaternion.Euler(rot_x_cord, rot_y_cord, rot_z_cord);
            Vector3 scl = new Vector3(scl_x_cord, scl_y_cord, scl_z_cord);

            for (int j = 0; j < objectArray.Length; j++)
            {
                if (objectArray[j].name == objectName)
                {
                    // INSTANTIATE HERE
                    GameObject temp = Instantiate(objectArray[j].gameObject, pos, rot);
                    temp.transform.localScale = scl;

                    if (linkID >= 0)
                    {
                        listOfLinkables.Add(new KeyValuePair<int, GameObject>(linkID, temp));
                    }
                }
                else
                {
                    Debug.Log("No object in placeable object array");
                }
            }
 
        }
    }

    // re-link objects together
    private void LinkObjects()
    {
        // check IDs
        // for every item in list
        for (int i = 0; i < listOfLinkables.Count; i++)
        {
            // get values of individual
            int linkID = listOfLinkables[i].Key;
            GameObject firstObjectToLink = listOfLinkables[i].Value;

            for (int j = i + 1; j < listOfLinkables.Count; j++)
            {
                if (linkID == listOfLinkables[j].Key)
                {
                    // send link information to create link 
                    // send value of for i and j
                    GameObject first = listOfLinkables[i].Value;
                    GameObject second = listOfLinkables[j].Value;

                    //linkObjects_script.GetComponent<LinkObjects>().setLinkedObjects(first, second);
                    showLinkManager_script.AddLink(first, second);
                }
            }
        }
        

    }
}
