using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCandyState : State
{

    GridControllerManager gridController;
    

    public SwapCandyState(StateManager sm) : base(sm)
    {
        m_nameOfState = Constants.STATE_SWAP;
    }

    
    public override void OnEnter()
    {
        base.OnEnter();
        gridController = GameManager.instance.m_gridControllerManager;
        
    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        if (gridController.m_secondClick != null)
        {
            if (gridController.CanSwap())
            {
                gridController.SwapCandys(gridController.m_firstClick, gridController.m_secondClick);
                gridController.EmptyClickPosition();
                stateManager.ChangeState(Constants.STATE_CHECKCOMBO);
            }
            else gridController.EmptyClickPosition();

        }
    }

    public override void OnExit()
    {
        base.OnExit();
        

    }

    


    

   

}
