using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCandy : State
{

    GridController gridController;

    public SwapCandy(StateManager sm) : base(sm)
    {
        nameOfState = Constants.STATE_SWAP;
    }

    
    public override void OnEnter()
    {
        base.OnEnter();
        gridController = GameManager.instance.gridController;
        
    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        if (gridController.secondClick != null)
        {
            if (gridController.CanSwap() )
            {
                gridController.SwapCandys(gridController.firstClick, gridController.secondClick);
                gridController.EmptyClickPosition();
                GameManager.instance.stateManager.ChangeState(Constants.STATE_CHECKCOMBO);
            }
            else gridController.EmptyClickPosition();

        }
    }

    public override void OnExit()
    {
        base.OnExit();
        

    }

    


    

   

}
