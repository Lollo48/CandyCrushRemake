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
        GameManager.instance.checkComboManager.StoreCandiesForRowCombination();
        GameManager.instance.checkComboManager.StoreCandiesForColumnCombination();
        GameManager.instance.checkComboManager.ColumnCombo();
        GameManager.instance.checkComboManager.RowCombo();
        
        //Debug.Log(" id caramella (0,0)" + GameManager.instance.gridManager.mapTiles[new Vector2Int (0,0)].data.candyParent.ID );

    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        if (GameManager.instance.checkComboManager.AllCombos.Count <= 2)
        {
            GameManager.instance.stateManager.ChangeState(Constants.STATE_SWAP);
        }
        else
        {
            GameManager.instance.checkComboManager.Destroyer(GameManager.instance.checkComboManager.AllCombos);
            GameManager.instance.checkComboManager.ListClear();
            GameManager.instance.stateManager.ChangeState(Constants.STATE_REFILL);
        }



    }

    public override void OnExit()
    {
        base.OnExit();

        

    }





}
