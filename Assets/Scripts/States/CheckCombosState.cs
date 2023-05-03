using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCombosState : State
{
    CheckComboManager checkComboManager;
    GridController gridController;

    public CheckCombosState(StateManager sm) : base(sm)
    {
        nameOfState = Constants.STATE_CHECKCOMBO;
    }


    public override void OnEnter()
    {
        base.OnEnter();
        checkComboManager = GameManager.instance.checkComboManager;
        gridController = GameManager.instance.gridController;
        checkComboManager.StoreCandiesForRowCombination();
        checkComboManager.StoreCandiesForColumnCombination();
        checkComboManager.ColumnCombo();
        checkComboManager.RowCombo();
        
        //Debug.Log(" id caramella (0,0)" + GameManager.instance.gridManager.mapTiles[new Vector2Int (0,0)].data.candyParent.ID );

    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        if (checkComboManager.AllCombos.Count <= 2)
        {
            gridController.EmptyClickPosition();
            gridController.SwapCandys(gridController.target2, gridController.target1);
            stateManager.ChangeState(Constants.STATE_SWAP);
        }
        else
        {
            checkComboManager.Destroyer(checkComboManager.AllCombos);
            checkComboManager.ListClear();
            stateManager.ChangeState(Constants.STATE_REFILL);
        }



    }

    public override void OnExit()
    {
        base.OnExit();
        


    }





}
