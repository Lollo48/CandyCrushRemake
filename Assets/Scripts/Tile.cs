using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    public TileData data;

    



    public void Initialize(GridManager gridM, int rowInit, int columnInit, Candy candyParent)
    {
        data = new TileData(gridM, rowInit, columnInit, candyParent);

    }




    private void OnMouseDown()
    {
        data.gm.SaveClickPosition(transform);
        Debug.Log( " Row " + data.row + " column " + data.column);
        Debug.Log("firstClick" + data.gm.firstClick + " secondClick" + data.gm.secondClick);
    }






}
