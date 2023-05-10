using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCombosState : State
{
    CheckComboManager m_checkComboManager;
    GridControllerManager m_gridController;
    RefillManager m_refillManager;

    public CheckCombosState(StateManager sm) : base(sm)
    {
        m_nameOfState = Constants.STATE_CHECKCOMBO;
    }


    public override void OnEnter()
    {
        base.OnEnter();
        
        m_checkComboManager = GameManager.instance.m_checkComboManager;
        m_gridController = GameManager.instance.m_gridControllerManager;
        m_refillManager = GameManager.instance.m_reFillManager;
        m_checkComboManager.StoreCandiesForRowCombination();
        m_checkComboManager.StoreCandiesForColumnCombination();
        m_checkComboManager.ColumnCombo();
        m_checkComboManager.RowCombo();
        //Debug.Log(" id caramella (0,0)" + GameManager.instance.gridManager.mapTiles[new Vector2Int (0,0)].data.candyParent.ID );

    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        if (!m_refillManager.isEmpty())
        {
            if (m_checkComboManager.AllCombos.Count <= 2)
            {
                m_gridController.EmptyClickPosition();
                m_gridController.SwapCandys(m_gridController.Target2, m_gridController.Target1);
                
                stateManager.ChangeState(Constants.STATE_SWAP);
            }
            else
            {
                m_checkComboManager.Destroyer(m_checkComboManager.AllCombos);
                stateManager.ChangeState(Constants.STATE_REFILL);

            }
        }
        else
        {
            
            stateManager.ChangeState(Constants.STATE_REFILL);
        }    



    }

    public override void OnExit()
    {
        base.OnExit();
        m_checkComboManager.ListClear();


    }





}
