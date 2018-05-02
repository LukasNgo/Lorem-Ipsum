using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartArea : MonoBehaviour {

    public static StartArea instance = null;

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
        gameObject.GetComponent<Collider>().enabled = false;
    }

    public void ObjectOff()
    {
        on = false;
        rend.enabled = true;
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
