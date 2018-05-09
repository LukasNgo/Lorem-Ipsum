using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnLinkState : MonoBehaviour {

    [SerializeField]
    private bool m_isEmitter = false;
    
    private LinkObjects m_linkObjects_script;

    public void OnEnable()
    {
        m_linkObjects_script = GameObject.Find("P_RightController").GetComponent<LinkObjects>();
    }

    public void GetIsEmitter()
    {
        m_linkObjects_script.setEmitterState(m_isEmitter);
    }
}
