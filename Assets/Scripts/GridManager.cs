using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridManager : MonoBehaviour
{

    //dividere le competenze con i controller
    //aggiungere pull system 
    //candyManager/controller 


    public Tile tilePrefab;
    public int maxRow;
    public int maxColumn;
    private Grid gridData;
    public Dictionary<Vector2Int, Tile> mapTiles = new Dictionary<Vector2Int, Tile>();


    


    public Vector3 m_offset;

    private void Awake()
    {
        gridData = GetComponent<Grid>();
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
                var tile = Instantiate(tilePrefab, new Vector3(x, y, 0) + m_offset, Quaternion.identity, transform);

                mapTiles[new Vector2Int(row, column)] = tile;

                tile.Initialize(this, row, column);

                tile.transform.localScale = gridData.cellSize;

                x -= 1 * (gridData.cellSize.x + gridData.cellGap.x);

                tile.name = "Tile - (" + row.ToString() + " - " + column.ToString() + ")";

            }
            x = startPosition.x;
            y -= 1 * (gridData.cellSize.z + gridData.cellGap.z);
        }
    }


}
