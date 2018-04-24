using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingFile : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string Test = "Name:blablabla (HELLO)";

        Test = Test.Substring(Test.IndexOf(":") + 1);

        Debug.Log(Test);

        Test = Test.Substring(0, Test.IndexOf(" "));

        Debug.Log(Test);

        bool testing = Test.Contains("bla");

        Debug.Log(testing);

        string Test2 = "bla, bla, bla";

        string[] Test2array = Test2.Split(',');
        
        foreach(string s in Test2array)
        {
            Debug.Log(s);
        }
    }
	
}
