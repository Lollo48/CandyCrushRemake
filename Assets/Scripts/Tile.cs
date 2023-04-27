using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    public TileData data;
    GridController gridController;


    private void Awake()
    {
        gridController = GameManager.instance.gridController;
    }

   

    public void Initialize(GridManager gridM, int rowInit, int columnInit)
    {
        data = new TileData(gridM, rowInit, columnInit);

    }
    



    private void OnMouseDown()
    {
        gridController.SaveClickPosition(transform);
        //Debug.Log( " Row " + data.row + " column " + data.column);
        //Debug.Log("firstClick" + data.gm.firstClick + " secondClick" + data.gm.secondClick);
    }






}
