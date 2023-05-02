using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateManager : MonoBehaviour
{
    public State currentState;
    public Dictionary<string, State> listOfStates = new Dictionary<string, State>();

    GridManager gridManager;


    // Start is called before the first frame update
    void Awake()
    {
        SetupStates();
        currentState = listOfStates[Constants.STATE_SWAP];
        currentState.OnEnter();
        gridManager = GameManager.instance.gridManager;

    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
       

    }


    public void SetupStates()
    {
        listOfStates.Add(Constants.STATE_SWAP, new SwapCandy(this));
        listOfStates.Add(Constants.STATE_CHECKCOMBO, new CheckCombos(this));

    }

    public void ChangeState(string key)
    {
        if (currentState.nameOfState == key) return;
        currentState?.OnExit();
        currentState = listOfStates[key];
        currentState?.OnEnter();
    }



}