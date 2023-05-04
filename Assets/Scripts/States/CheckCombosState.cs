using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCombosState : State
{
    CheckComboManager checkComboManager;
    GridControllerManager gridController;
    RefillManager refillManager;

    public CheckCombosState(StateManager sm) : base(sm)
    {
        m_nameOfState = Constants.STATE_CHECKCOMBO;
    }


    public override void OnEnter()
    {
        base.OnEnter();
        
        checkComboManager = GameManager.instance.m_checkComboManager;
        gridController = GameManager.instance.m_gridControllerManager;
        refillManager = GameManager.instance.m_reFillManager;
        checkComboManager.StoreCandiesForRowCombination();
        checkComboManager.StoreCandiesForColumnCombination();
        checkComboManager.ColumnCombo();
        checkComboManager.RowCombo();
        
        //Debug.Log(" id caramella (0,0)" + GameManager.instance.gridManager.mapTiles[new Vector2Int (0,0)].data.candyParent.ID );

    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        if (!refillManager.isEmpty())
        {
            if (checkComboManager.m_allCombos.Count <= 2)
            {
                gridController.EmptyClickPosition();
                gridController.SwapCandys(gridController.m_target2, gridController.m_target1);
                
                stateManager.ChangeState(Constants.STATE_SWAP);
            }
            else
            {
                checkComboManager.Destroyer(checkComboManager.m_allCombos);
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
        checkComboManager.ListClear();


    }





}
