using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridManager : MonoBehaviour
{
    public Tile tilePrefab;
    public int maxRow;
    public int maxColumn;
    private Grid gridData;
    public Dictionary<Vector2Int, TileData> mapTiles = new Dictionary<Vector2Int, TileData>();


    public Transform firstClick;
    public Transform secondClick;


    public CandyData candyDatas;

    public bool isSwapped = false;
    

    public Vector3 m_offset;

    private void Awake()
    {
        gridData = GetComponent<Grid>();
    }

    private void Start()
    {
        GenerateGrid();
    }



    private void GenerateGrid()
    {
        Vector3 startPosition = new Vector3(maxColumn * (gridData.cellSize.x + gridData.cellGap.x) / 2, maxRow * (gridData.cellSize.z + gridData.cellGap.z) / 2, 0);
        float x = startPosition.x;
        float y = startPosition.y;

        for (int row = 0; row < maxRow; row++)
        {
            for (int column = 0; column < maxColumn; column++)
            {

                choseCandy(row, column);

                var tile = Instantiate(tilePrefab, new Vector3(x, y, 0) + m_offset, Quaternion.identity, transform);

                int witchCandy = Random.Range(0, candyDatas.candies.Count);

                Candy candy = Instantiate(candyDatas.candies[witchCandy], tile.transform);

                mapTiles[new Vector2Int(row, column)] = tile.data;

                tile.Initialize(this, row, column, candy);

                tile.transform.localScale = gridData.cellSize;
                x -= 1 * (gridData.cellSize.x + gridData.cellGap.x);

                tile.name = "Tile - (" + row.ToString() + " - " + column.ToString() + ")";

            }
            x = startPosition.x;
            y -= 1 * (gridData.cellSize.z + gridData.cellGap.z);
        }
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


    public Candy GetCandys(int row, int column)
    {
        if (column < 0 || column <= maxColumn || row < 0 || row <= maxRow)
        {
            Debug.Log("CandyNotFound");
            return null;
        }
        else
        {
            Candy candy1 = mapTiles[new Vector2Int(row, column)].candyParent;
            return candy1;
        }
        //if (mapTiles.ContainsKey(new Vector2Int(row, column)))
        //{
            
        //}
        
        //return null;
    }

    public bool CanSwap()
    {
        Tile FirstClickedTile = firstClick.GetComponent<Tile>();
        Tile SecondClickedTile = secondClick.GetComponent<Tile>();

        if (FirstClickedTile.data.column == SecondClickedTile.data.column)
        {
            if (Mathf.Abs(FirstClickedTile.data.row - SecondClickedTile.data.row) == 1)
            {
                isSwapped = true;
                return true;
            }
                
            else
                return false;
        }
        else if (FirstClickedTile.data.row == SecondClickedTile.data.row)
        {
            if (Mathf.Abs(FirstClickedTile.data.column - SecondClickedTile.data.column) == 1)
            {
                isSwapped = true;
                return true; 
            }
                
            else
                return false;
        }
        else return false;

    }


    public void choseCandy(int row, int column)
    {

        //Choose what sprite to use for this cell
        Candy left1 = GetCandys(row - 1, column);
        Candy left2 = GetCandys(row - 2, column);

        if (left2 != null && left1.ID == left2.ID)
        {
            Destroy(left2);

        }

        //Choose what sprite to use for this cell
        Candy down1 = GetCandys(row, column - 1);
        Candy down2 = GetCandys(row, column - 2);
        if (down2 != null && down1.ID == down2.ID)
        {

        }


    }









}
