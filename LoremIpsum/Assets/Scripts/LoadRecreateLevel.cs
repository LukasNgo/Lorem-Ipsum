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

    private bool nameExists = false;
    private bool idExists = false;
    private bool posExists = false;
    private bool rotExists = false;
    private bool sclExists = false;

    private string name;
    private int linkID;
    private Vector3 pos;
    private Quaternion rot;
    private Vector3 scl;

    private void Start()
    {
        m_objectList_script = GameObject.Find("insertObjects").GetComponent<ObjectList>();
        objectArray = m_objectList_script.getObjectArray();

        Debug.Log("Showing array of objects: ");
        foreach (GameObject o in objectArray)
        {
            string toSplit = o.name;
            string[] splitResult = toSplit.Split(new char[] { ' ', '(' });
            o.name = splitResult[0];
            Debug.Log(o.name);
        }
    }

    public void RecreateLevel(string[] fileContent)
    {
        m_fileContent = fileContent;
        DeleteSceneObjects();
        InstantiateObjects();
        // ** UNCOMMENT **
        //LinkObjects();
    }

    // delete objects already in scene; ready for loading
    private void DeleteSceneObjects()
    {
        string[] tags =
        {
            "SelectableObjects"
            // ** UNCOMMENT ** put commar
            //"VisualLinks"
        };

        foreach (string tag in tags)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject o in objects)
            {
                Destroy(o.gameObject);
                Debug.Log("Destroying object: " + o.name);
            }
        }
    }

    // instantiate objects from text file
    private void InstantiateObjects()
    { 
        // check placeable objects list and place that prefab
        Debug.Log("Going through array:");
        for (int i = 0; i < m_fileContent.Length; i++)
        {
            Debug.Log("Declaring variables.");
            string objectName = "";
            string LinkID = "";
            string position = "";
            string rotation = "";
            string scale = "";

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

            Debug.Log("Starting at: " + m_fileContent[i]);
            if (m_fileContent[i].Contains("Name:"))
            {               
                objectName = m_fileContent[i].Substring(m_fileContent[i].IndexOf(":") + 1);
                Debug.Log(objectName);
                objectName = objectName.Substring(0, objectName.IndexOf(" "));
                Debug.Log(objectName);
                objectName = objectName.Substring(0, objectName.IndexOf("("));
                Debug.Log(objectName);

                nameExists = true;

                if (nameExists)
                {
                    name = objectName;
                }
                Debug.Log("Name: " + objectName);
            }
        
            else if (m_fileContent[i].Contains("LinkID:"))
            {               
                LinkID = m_fileContent[i].Substring(m_fileContent[i].IndexOf(":") + 1);
                idExists = true;


                if (idExists)
                {
                    linkID = int.Parse(LinkID);
                }
                Debug.Log("LinkID: " + LinkID);
            }

            else if (m_fileContent[i].Contains("Position:"))
            {                
                position = m_fileContent[i].Substring(m_fileContent[i].IndexOf("(") + 1);
                Debug.Log(position);
                position = position.Substring(0, position.IndexOf(")"));
                Debug.Log(position);

                string[] positionArray = position.Split(',');

                foreach (string p in positionArray)
                {
                    p.Trim();
                }

                x_cord = float.Parse(positionArray[0]);
                y_cord = float.Parse(positionArray[1]);
                z_cord = float.Parse(positionArray[2]);

                posExists = true;

                if (posExists)
                {
                    pos = new Vector3(x_cord, y_cord, z_cord);
                }
                Debug.Log("Position (x, y, z)" + x_cord + ", " + y_cord + ", " + z_cord);

            }

            else if (m_fileContent[i].Contains("Rotation:"))
            {               
                rotation = m_fileContent[i].Substring(m_fileContent[i].IndexOf("(") + 1);
                rotation = rotation.Substring(0, rotation.IndexOf(")"));

                string[] rotationArray = rotation.Split(',');
                
                foreach (string r in rotationArray)
                {
                    r.Trim();
                }

                rot_x_cord = float.Parse(rotationArray[0]);
                rot_y_cord = float.Parse(rotationArray[1]);
                rot_z_cord = float.Parse(rotationArray[2]);
                rot_w_cord = float.Parse(rotationArray[3]);

                rotExists = true;

                if (rotExists)
                {
                    rot = Quaternion.Euler(rot_x_cord, rot_y_cord, rot_z_cord);
                }
                Debug.Log("Rotation (x, y, z, w)" + rot_x_cord + ", " + rot_y_cord + ", " + rot_z_cord + "," + rot_w_cord);
            }

            else if (m_fileContent[i].Contains("Scale:"))
            {
                scale = m_fileContent[i].Substring(m_fileContent[i].IndexOf("(") + 1);
                scale = scale.Substring(0, scale.IndexOf(")"));

                string[] scaleArray = scale.Split(',');

                foreach (string s in scaleArray)
                {
                    s.Trim();
                }

                scl_x_cord = float.Parse(scaleArray[0]);
                scl_y_cord = float.Parse(scaleArray[1]);
                scl_z_cord = float.Parse(scaleArray[2]);

                sclExists = true;

                if (sclExists)
                {
                    scl = new Vector3(scl_x_cord, scl_y_cord, scl_z_cord);
                }
                Debug.Log("Scale (x, y, z)" + scl_x_cord + ", " + scl_y_cord + ", " + scl_z_cord);
            }

            // check name against placeable objects list

            Debug.Log(name + ", " + linkID + ", " + pos + ", " + rot + ", " + scl);

            if (nameExists && idExists && posExists && rotExists && sclExists)
            {
                Debug.Log("Starting object instantiation task.");
                for (int j = 0; j < objectArray.Length; j++)
                {
                    Debug.Log("Searching for: " + name);
                    if (objectArray[j].name == name)
                    {
                        Debug.Log("objectInArray selected: " + objectArray[j].name);
                        // INSTANTIATE HERE
                        GameObject temp = Instantiate(objectArray[j].gameObject, pos, rot);
                        temp.transform.localScale = scl;
                        temp.SetActive(true);

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
                nameExists = false;
                idExists = false;
                posExists = false;
                rotExists = false;
                sclExists = false;
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

                    // ** UNCOMMENT **
                    //linkObjects_script.GetComponent<LinkObjects>().setLinkedObjects(first, second);
                    showLinkManager_script.AddLink(first, second);
                }
            }
        }
        

    }
}

