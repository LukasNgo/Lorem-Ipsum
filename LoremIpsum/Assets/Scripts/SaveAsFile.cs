using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveAsFile : MonoBehaviour {

    public string[] fileContent = {"Test"};

    public GameObject saveMenu;
    public Text fileNameText;
    public GameObject overwriteMenu;

    public string m_basePath = @"c:\temp\";

    private string fileName = "test";
    private string m_currentPath = @"c:\temp\";

    public void SaveLevel()
    {
        fileName = fileNameText.text;

        m_currentPath = m_basePath + fileName + ".txt";

        if (!(System.IO.File.Exists(m_currentPath)))
        {
            Save();
        }
        else
        {
            saveMenu.SetActive(false);
            overwriteMenu.SetActive(true);
        }
    }

    public void Save()//Done like this so it can be overwritten
    {
        System.IO.File.WriteAllLines(m_currentPath, fileContent);
    }

    public void NewFileContent(List<string> newContent)
    {
        int size = newContent.Count;
        string[] newFileContent = new string[size];

        for (int i = 0; i < size; i++)
        {
            newFileContent[i] = newContent[i];
        }

        fileContent = newFileContent;
    }

}
