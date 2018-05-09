using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelListButton : MonoBehaviour {

    public LoadFile manager;
    public string levelName;
    public Text myText;

    public void SetText(string text)
    {
        levelName = text;
        string[] fileSplit = levelName.Split('\\');

        myText.text = fileSplit[fileSplit.Length - 1];
    }

    public void OnClick()
    {
        manager.currentPath = levelName;
    }

}
