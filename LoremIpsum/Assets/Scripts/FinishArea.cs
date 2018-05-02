using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishArea : MonoBehaviour {

    public static FinishArea instance = null;

    public PlayLevelManager myManager;
    public bool on = false;

    private Renderer rend;

    void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

    private void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    public void ObjectOn()
    {
        on = true;
        rend.enabled = false;
        gameObject.GetComponent<Collider>().isTrigger = true;
    }

    public void ObjectOff()
    {
        on = false;
        rend.enabled = true;
        gameObject.GetComponent<Collider>().isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (on == true)
        {
            myManager.WinLevel();
        }
    }
}
