using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateManager : MonoBehaviour
{
    public State CurrentState;
    public Dictionary<string, State> ListOfStates = new Dictionary<string, State>();


    // Start is called before the first frame update
    void Awake()
    {
        SetupStates();
        CurrentState = ListOfStates[Constants.STATE_SWAP];
        CurrentState.OnEnter();

    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.OnUpdate();

    }


    public void SetupStates()
    {
        ListOfStates.Add(Constants.STATE_SWAP, new SwapCandyState(this));
        ListOfStates.Add(Constants.STATE_CHECKCOMBO, new CheckCombosState(this));
        ListOfStates.Add(Constants.STATE_REFILL, new ReFillState(this));

    }

    public void ChangeState(string key)
    {
        if (CurrentState.m_nameOfState == key) return;
        CurrentState?.OnExit();
        CurrentState = ListOfStates[key];
        CurrentState?.OnEnter();
    }



}