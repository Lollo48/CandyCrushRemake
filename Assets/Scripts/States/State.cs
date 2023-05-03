using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class State
{
    protected StateManager stateManager;
    public string m_nameOfState;

    public State(StateManager sm)
    {
        stateManager = sm;
    }

    public virtual void OnEnter() { /*Debug.Log("OnEnter " + nameOfState);*/ }
    public virtual void OnUpdate() {/* Debug.Log("OnUpdate " + nameOfState);*/ }
    public virtual void OnExit() { /*Debug.Log("OnExit " + nameOfState);*/ }
}
