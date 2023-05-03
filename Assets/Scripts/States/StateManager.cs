using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateManager : MonoBehaviour
{
    public State currentState;
    public Dictionary<string, State> listOfStates = new Dictionary<string, State>();


    // Start is called before the first frame update
    void Awake()
    {
        SetupStates();
        currentState = listOfStates[Constants.STATE_SWAP];
        currentState.OnEnter();

    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();

    }


    public void SetupStates()
    {
        listOfStates.Add(Constants.STATE_SWAP, new SwapCandyState(this));
        listOfStates.Add(Constants.STATE_CHECKCOMBO, new CheckCombosState(this));
        listOfStates.Add(Constants.STATE_REFILL, new ReFillState(this));

    }

    public void ChangeState(string key)
    {
        if (currentState.nameOfState == key) return;
        currentState?.OnExit();
        currentState = listOfStates[key];
        currentState?.OnEnter();
    }



}