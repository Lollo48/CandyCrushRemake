using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillManager : MonoBehaviour
{
    GridManager gridManager;


    private void Awake()
    {
        gridManager = GameManager.instance.m_gridManager;
    }


    public void CheckForEmptyCandies()
    {
        for (int v = 0; v < gridManager.m_maxRow; v++)
        {
            for (int i = 0; i < gridManager.m_maxColumn; i++)
            {
                if(gridManager.m_mapTiles[new Vector2Int(v, i)].data.candyChildren == null)
                {

                    Debug.Log("missing candy " );

                }

            }
        }



    }





}
