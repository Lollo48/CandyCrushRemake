using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCombos : State
{
    GridManager gridManager;
    CheckComboManager checkComboManager;

    public CheckCombos(StateManager sm) : base(sm)
    {
        nameOfState = Constants.STATE_CHECKCOMBO;
    }


    public override void OnEnter()
    {
        base.OnEnter();
        gridManager = GameManager.instance.gridManager;
        checkComboManager = GameManager.instance.checkComboManager;
        GameManager.instance.checkComboManager.FindRowCombination();
        GameManager.instance.checkComboManager.RowCombo();
        //Debug.Log(" id caramella (0,0)" + GameManager.instance.gridManager.mapTiles[new Vector2Int (0,0)].data.candyParent.ID );

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
