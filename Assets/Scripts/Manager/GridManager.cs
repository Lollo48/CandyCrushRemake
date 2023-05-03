using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridManager : MonoBehaviour
{

    public Tile m_tilePrefab;
    public int m_maxRow;
    public int m_maxColumn;
    private Grid gridData;
    public Dictionary<Vector2Int, Tile> m_mapTiles = new Dictionary<Vector2Int, Tile>();

    public Vector3 m_offset;

    private void Awake()
    {
        gridData = GetComponent<Grid>();
        GenerateGrid();
        
    }


    private void GenerateGrid()
    {
        Vector3 startPosition = new Vector3(m_maxColumn * (gridData.cellSize.x + gridData.cellGap.x) / 2, m_maxRow * (gridData.cellSize.z + gridData.cellGap.z) / 2, 0);
        float x = startPosition.x;
        float y = startPosition.y;

        for (int row = 0; row < m_maxRow; row++)
        {
            for (int column = 0; column < m_maxColumn; column++)
            {
                var tile = Instantiate(m_tilePrefab, new Vector3(x, y, 0) + m_offset, Quaternion.identity, transform);

                m_mapTiles[new Vector2Int(row, column)] = tile;

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
