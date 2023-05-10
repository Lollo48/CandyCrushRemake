using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridManager : MonoBehaviour
{

    public Tile TilePrefab;
    public int MaxRow;
    public int MaxColumn;
    private Grid m_gridData;
    public Dictionary<Vector2Int, Tile> MapTiles = new Dictionary<Vector2Int, Tile>();

    public Vector3 Offset;

    private void Awake()
    {
        m_gridData = GetComponent<Grid>();
        GenerateGrid();
        
    }


    private void GenerateGrid()
    {
        Vector3 startPosition = new Vector3(MaxColumn * (m_gridData.cellSize.x + m_gridData.cellGap.x) / 2, MaxRow * (m_gridData.cellSize.z + m_gridData.cellGap.z) / 2, 0);
        float x = startPosition.x;
        float y = startPosition.y;

        for (int row = 0; row < MaxRow; row++)
        {
            for (int column = 0; column < MaxColumn; column++)
            {
                var tile = Instantiate(TilePrefab, new Vector3(x, y, 0) + Offset, Quaternion.identity, transform);

                MapTiles[new Vector2Int(row, column)] = tile;

                tile.Initialize(this, row, column);

                tile.transform.localScale = m_gridData.cellSize;

                x -= 1 * (m_gridData.cellSize.x + m_gridData.cellGap.x);

                tile.name = "Tile - (" + row.ToString() + " - " + column.ToString() + ")";

            }
            x = startPosition.x;
            y -= 1 * (m_gridData.cellSize.z + m_gridData.cellGap.z);
        }
    }


}
