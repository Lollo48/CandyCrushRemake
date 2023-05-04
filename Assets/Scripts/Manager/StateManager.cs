using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateManager : MonoBehaviour
{
    public State m_currentState;
    public Dictionary<string, State> m_listOfStates = new Dictionary<string, State>();


    // Start is called before the first frame update
    void Awake()
    {
        SetupStates();
        m_currentState = m_listOfStates[Constants.STATE_SWAP];
        m_currentState.OnEnter();

    }

    // Update is called once per frame
    void Update()
    {
        m_currentState.OnUpdate();

    }


    public void SetupStates()
    {
        m_listOfStates.Add(Constants.STATE_SWAP, new SwapCandyState(this));
        m_listOfStates.Add(Constants.STATE_CHECKCOMBO, new CheckCombosState(this));
        m_listOfStates.Add(Constants.STATE_REFILL, new ReFillState(this));

    }

    public void ChangeState(string key)
    {
        if (m_currentState.m_nameOfState == key) return;
        m_currentState?.OnExit();
        m_currentState = m_listOfStates[key];
        m_currentState?.OnEnter();
    }



}