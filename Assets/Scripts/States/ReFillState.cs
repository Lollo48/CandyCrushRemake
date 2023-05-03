using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReFillState : State    
{

    RefillManager refillManager;

    public ReFillState(StateManager sm) : base(sm)
    {
        m_nameOfState = Constants.STATE_REFILL;
    }


    public override void OnEnter()
    {
        base.OnEnter();
        refillManager = GameManager.instance.m_reFillManager;
        refillManager.CheckForEmptyCandies();

    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        
    }

    public override void OnExit()
    {
        base.OnExit();


    }



}
