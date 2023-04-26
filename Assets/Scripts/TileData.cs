using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileData
{
    public int row;
    public int column;
    public Candy candyParent;
    public GridManager gm;
    

    public TileData(GridManager gridManager, int newRow, int newColumn, Candy newCandyParent)
    {
        row = newRow;
        column = newColumn;
        candyParent = newCandyParent;
        gm = gridManager;
    }
}
