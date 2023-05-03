using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{

    public Transform firstClick;
    public Transform secondClick;

    GridManager gridManager;
    CandyController CandyController;

    [HideInInspector]
    public Transform target1;
    [HideInInspector]
    public Transform target2;

    private void Awake()
    {
        gridManager = GameManager.instance.gridManager;
        CandyController = GameManager.instance.candyController;
    }


    public void SaveClickPosition(Transform target)
    {
        if (firstClick == null)
        {
            firstClick = target;
            target1 = target;
        }
        else
        {
            secondClick = target;
            target2 = target;
        }
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

        Parent1.GetComponent<Tile>().data.candyChildren = candy2;

        Parent2.GetComponent<Tile>().data.candyChildren = candy1;

    }

    public bool CanSwap()
    {
        Tile FirstClickedTile = firstClick.GetComponent<Tile>();
        Tile SecondClickedTile = secondClick.GetComponent<Tile>();

        if (FirstClickedTile.data.column == SecondClickedTile.data.column)
        {
            if (Mathf.Abs(FirstClickedTile.data.row - SecondClickedTile.data.row) == 1)
            {
                
                return true;
            }
            else
            {

                return false;
            }

        }
        else if (FirstClickedTile.data.row == SecondClickedTile.data.row)
        {
            if (Mathf.Abs(FirstClickedTile.data.column - SecondClickedTile.data.column) == 1 )
            {
                
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
