using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadFile : MonoBehaviour
{

    public string basePath = @"c:\temp\";
    public GameObject levelButtonTemplate;
    public string currentPath = @"c:\temp\";

    private string[] m_fileContent;
    private List<GameObject> buttons = new List<GameObject>();

    private void OnEnable()
    {
        PopulateList();
    }

    private void OnDisable()
    {
        UnPopulateList();
    }

    public void LoadLevel()
    {
        if (File.Exists(currentPath))
        {
            m_fileContent = File.ReadAllLines(currentPath);
        }

        //Send String to load level
        for (int i = 0; i < m_fileContent.Length; i++)//Loading Debug
        {
            Debug.Log(m_fileContent[i]);
        }

    }

    public void PopulateList()
    {
        string[] levelNameList;
        levelNameList = Directory.GetFiles(basePath, "*.txt");

        GameObject tempButton;

        for (int i = 0; i < levelNameList.Length; i++)
        {
            tempButton = Instantiate(levelButtonTemplate);
            tempButton.SetActive(true);
            tempButton.GetComponent<LevelListButton>().SetText(levelNameList[i]);

            tempButton.transform.SetParent(levelButtonTemplate.transform.parent, false);

            buttons.Add(tempButton);
        }
    }

    public void UnPopulateList()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            GameObject toDelete = buttons[i];
            buttons.Remove(toDelete);
            Destroy(toDelete);
        }
    }
}
