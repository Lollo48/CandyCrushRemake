using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCombos : State
{
    GridManager gridManager;


    public CheckCombos(StateManager sm) : base(sm)
    {
        nameOfState = Constants.STATE_CHECKCOMBO;
    }


    public override void OnEnter()
    {
        base.OnEnter();
        gridManager = GameManager.instance.gridManager;

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
