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

        myText.text = text;
    }

    public void OnClick()
    {
        manager.currentPath = levelName;
    }

}
