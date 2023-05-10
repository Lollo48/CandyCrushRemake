using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCandyState : State
{

    GridControllerManager m_gridController;
    

    public SwapCandyState(StateManager sm) : base(sm)
    {
        m_nameOfState = Constants.STATE_SWAP;
    }

    
    public override void OnEnter()
    {
        base.OnEnter();
        m_gridController = GameManager.instance.m_gridControllerManager;

        
    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        if (m_gridController.SecondClick != null)
        {
            if (m_gridController.CanSwap())
            {
                m_gridController.SwapCandys(m_gridController.FirstClick, m_gridController.SecondClick);
                //gridController.StartCoroutine(gridController.SwapCandyesWithLerp(gridController.m_firstClick, gridController.m_secondClick));
                stateManager.ChangeState(Constants.STATE_CHECKCOMBO);
            }
            else m_gridController.EmptyClickPosition();

        }
    }

    public override void OnExit()
    {
        base.OnExit();
        m_gridController.EmptyClickPosition();

    }

    


    

   

}
