using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{

    public Transform firstClick;
    public Transform secondClick;

    GridManager gridManager;
    CandyController CandyController;

    private void Awake()
    {
        gridManager = GameManager.instance.gridManager;
        CandyController = GameManager.instance.candyController;
    }

    public void SaveClickPosition(Transform target)
    {
        if (firstClick == null) firstClick = target;
        else secondClick = target;

    }

    public void EmptyClickPosition()
    {
        firstClick = null;
        secondClick = null;


    }

    public void SwapCandys(Transform Parent1, Transform Parent2)
    {
        var candy1 = Parent1.GetComponentInChildren<Candy>();

        var candy2 = Parent2.GetComponentInChildren<Candy>();

        candy1.transform.SetParent(Parent2, false);

        candy2.transform.SetParent(Parent1, false);

    }


    public bool CanSwap()
    {
        Tile FirstClickedTile = firstClick.GetComponent<Tile>();
        Tile SecondClickedTile = secondClick.GetComponent<Tile>();

        if (FirstClickedTile.data.column == SecondClickedTile.data.column)
        {
            if (Mathf.Abs(FirstClickedTile.data.row - SecondClickedTile.data.row) == 1)
            {

                //GameManager.instance.stateManager.ChangeState(Constants.STATE_CHECKCOMBO);
                return true;
            }
            else
            {

                return false;
            }

        }
        else if (FirstClickedTile.data.row == SecondClickedTile.data.row)
        {
            if (Mathf.Abs(FirstClickedTile.data.column - SecondClickedTile.data.column) == 1)
            {

                //GameManager.instance.stateManager.ChangeState(Constants.STATE_CHECKCOMBO);
                return true;
            }
            else
            {

                return false;

            }

        }
        else
        {

            return false;
        }


    }




   

}
