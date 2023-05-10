using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReFillState : State    
{

    RefillManager m_refillManager;
  

    public ReFillState(StateManager sm) : base(sm)
    {
        m_nameOfState = Constants.STATE_REFILL;
    }


    public override void OnEnter()
    {
        base.OnEnter();
        m_refillManager = GameManager.instance.m_reFillManager;
        m_refillManager.CheckForEmptyCandies();
       

    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        if (!m_refillManager.isEmpty()) stateManager.ChangeState(Constants.STATE_CHECKCOMBO);
        else stateManager.ChangeState(Constants.STATE_REFILL);



    }

    public override void OnExit()
    {
        base.OnExit();



    }



}
