using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReFillState : State    
{

    RefillManager refillManager;
    GridManager gridManager;
    CheckComboManager checkComboManager;
    GridControllerManager gridController;

    public ReFillState(StateManager sm) : base(sm)
    {
        m_nameOfState = Constants.STATE_REFILL;
    }


    public override void OnEnter()
    {
        base.OnEnter();
        checkComboManager = GameManager.instance.m_checkComboManager;
        gridController = GameManager.instance.m_gridControllerManager;
        refillManager = GameManager.instance.m_reFillManager;
        gridManager = GameManager.instance.m_gridManager;
        refillManager.CheckForEmptyCandies();
       

    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        if (!refillManager.isEmpty()) stateManager.ChangeState(Constants.STATE_CHECKCOMBO);
        else stateManager.ChangeState(Constants.STATE_REFILL);



    }

    public override void OnExit()
    {
        base.OnExit();
     


    }



}
