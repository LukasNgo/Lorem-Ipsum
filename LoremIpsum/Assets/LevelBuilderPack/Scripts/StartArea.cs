using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartArea : MonoBehaviour {

    public static StartArea instance = null;

    public PlayLevelManager myManager;
    public bool on = false;

    [SerializeField]
    private string ignoreRaycastLayer = "Ignore Raycast";
    [SerializeField]
    private string defaultLayer = "Default";

    private Renderer m_rend;

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
        m_rend = gameObject.GetComponent<Renderer>();
    }

    public void ObjectOn()
    {
        on = true;
        m_rend.enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.layer = LayerMask.NameToLayer(ignoreRaycastLayer);
    }

    public void ObjectOff()
    {
        on = false;
        m_rend.enabled = true;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.layer = LayerMask.NameToLayer(defaultLayer);
    }
}
