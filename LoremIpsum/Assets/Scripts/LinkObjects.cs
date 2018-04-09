using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LinkObjects : MonoBehaviour {

    // button.onClick.AddListener(delegate{SomeMethodName(SomeObject);});

    private GameObject[] m_linkableObjects = new GameObject[2];
    private Component[] m_componentsInObjects;

    private GameObject m_receiver;
    private GameObject m_emitter;

    private bool isEmitter = false;

    public void setLinkedObjects(GameObject _first, GameObject _second)
    {
        m_linkableObjects[0] = _first;
        m_linkableObjects[1] = _second;

        ReceiverOrEmitter();
        TargetObjectInUnityEvents();
    }

    private void ReceiverOrEmitter()
    {
        // go through each object that has been selected
        for (int i = 0; i < m_linkableObjects.Length; i++)
        {
            // get components of object
            m_componentsInObjects = m_linkableObjects[i].GetComponentsInChildren<Component>();

            foreach (Component comp in m_componentsInObjects)
            {
                comp.BroadcastMessage("GetIsEmitter");              
            }

            if(isEmitter == true)
            {
                m_emitter = m_linkableObjects[i];
            }
            else
            {
                m_receiver = m_linkableObjects[i];
            }
        }

        Debug.Log("Emitter: " + m_emitter);
        Debug.Log("Receiver: " + m_receiver);
    }

    private void TargetObjectInUnityEvents()
    {
        // Check for activatedEvent & deactivatedEvent fields in comps

        // insert other Object into parameter
    }

    public void setEmitterState(bool isEmitterState)
    {
        isEmitter = isEmitterState;
    }
}
