using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCandy : State
{

    GridManager gridManager;


    public SwapCandy(StateManager sm) : base(sm)
    {
        nameOfState = Constants.STATE_SWAP;
    }

    
    public override void OnEnter()
    {
        base.OnEnter();
        gridManager = GameManager.instance.gridManager;
  
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if(gridManager.secondClick!=null)
        {
            if (gridManager.CanSwap())
            {
                gridManager.SwapCandys(gridManager.firstClick, gridManager.secondClick);
                gridManager.EmptyClickPosition();
            }
            else gridManager.EmptyClickPosition();

        }
    }

    public override void OnExit()
    {
        base.OnExit();
        
    }

    


    

   

}
