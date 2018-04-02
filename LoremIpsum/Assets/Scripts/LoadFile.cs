using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadFile : MonoBehaviour {

    public string m_basePath = @"c:\temp\";
    public string fileName = "test";

    private string m_currentPath = @"c:\temp\";

    private string[] m_fileContent;

    public void LoadLevel()
    {
        m_currentPath = m_basePath + fileName + ".txt";

        if (System.IO.File.Exists(m_currentPath))
        {
            m_fileContent = System.IO.File.ReadAllLines(m_currentPath);
        }

        //Send String to load leve
        for (int i = 0; i < m_fileContent.Length; i++)//Loading Debug
        {
            Debug.Log(m_fileContent[i]);
        }

    }

}
