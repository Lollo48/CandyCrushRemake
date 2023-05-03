using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCombosState : State
{
    CheckComboManager checkComboManager;
    GridControllerManager gridController;

    public CheckCombosState(StateManager sm) : base(sm)
    {
        m_nameOfState = Constants.STATE_CHECKCOMBO;
    }


    public override void OnEnter()
    {
        base.OnEnter();
        checkComboManager = GameManager.instance.m_checkComboManager;
        gridController = GameManager.instance.m_gridControllerManager;
        checkComboManager.StoreCandiesForRowCombination();
        checkComboManager.StoreCandiesForColumnCombination();
        checkComboManager.ColumnCombo();
        checkComboManager.RowCombo();
        
        //Debug.Log(" id caramella (0,0)" + GameManager.instance.gridManager.mapTiles[new Vector2Int (0,0)].data.candyParent.ID );

    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        if (checkComboManager.m_allCombos.Count <= 2)
        {
            gridController.EmptyClickPosition();
            gridController.SwapCandys(gridController.m_target2, gridController.m_target1);
            stateManager.ChangeState(Constants.STATE_SWAP);
        }
        else
        {
            checkComboManager.Destroyer(checkComboManager.m_allCombos);
            checkComboManager.ListClear();
            stateManager.ChangeState(Constants.STATE_REFILL);
        }



    }

    public override void OnExit()
    {
        base.OnExit();
        


    }





}
