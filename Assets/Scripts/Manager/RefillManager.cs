using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillManager : MonoBehaviour
{
    GridManager gridManager;
    CandyControllerManager candyController;
    StateManager stateManager;

    private int IDcandyToSkipVertical;
    private int IDcandyToSkipHorizzontal;

    private void Awake()
    {
        gridManager = GameManager.instance.m_gridManager;
        candyController = GameManager.instance.m_candyControllerManager;
        stateManager = GameManager.instance.m_stateManager;
    }


    public void CheckForEmptyCandies()
    {
        for (int v = 0; v < gridManager.m_maxRow; v++)
        {
            for (int i = 0; i < gridManager.m_maxColumn; i++)
            {
                if(gridManager.m_mapTiles[new Vector2Int(v, i)].data.candyChildren == null)
                {

                    Tile tile = gridManager.m_mapTiles[new Vector2Int(v, i)];

                    int witchCandy = Random.Range(0, candyController.m_candyDatas.m_candies.Count);

                    if (candyController.choseCandy(v, i))
                    {
                        while (witchCandy == IDcandyToSkipVertical || witchCandy == IDcandyToSkipHorizzontal) witchCandy = Random.Range(0, candyController.m_candyDatas.m_candies.Count);
                    }

                    Candy candy = Instantiate(candyController.m_candyDatas.m_candies[witchCandy], tile.transform);


                    tile.data.candyChildren = candy;

                }
            }
        }
    }



    public bool isEmpty()
    {
        for (int v = 0; v < gridManager.m_maxRow; v++)
        {
            for (int i = 0; i < gridManager.m_maxColumn; i++)
            {
                if (gridManager.m_mapTiles[new Vector2Int(v, i)].data.candyChildren == null)
                {

                    return true;

                }
            }
        }

        return false;
    }



        
    

}
