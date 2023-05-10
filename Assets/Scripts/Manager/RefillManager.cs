using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillManager : MonoBehaviour
{
    GridManager m_gridManager;
    CandyControllerManager m_candyController;


    private int m_idCandyToSkipVertical;
    private int m_idCandyToSkipHorizzontal;

    private void Awake()
    {
        m_gridManager = GameManager.instance.m_gridManager;
        m_candyController = GameManager.instance.m_candyControllerManager;

    }


    public void CheckForEmptyCandies()
    {
        for (int v = 0; v < m_gridManager.MaxRow; v++)
        {
            for (int i = 0; i < m_gridManager.MaxColumn; i++)
            {
                if(m_gridManager.MapTiles[new Vector2Int(v, i)].data.candyChildren == null)
                {

                    Tile tile = m_gridManager.MapTiles[new Vector2Int(v, i)];

                    int witchCandy = Random.Range(0, m_candyController.m_candyDatas.m_candies.Count);

                    if (m_candyController.choseCandy(v, i))
                    {
                        while (witchCandy == m_idCandyToSkipVertical || witchCandy == m_idCandyToSkipHorizzontal) witchCandy = Random.Range(0, m_candyController.m_candyDatas.m_candies.Count);
                    }

                    Candy candy = Instantiate(m_candyController.m_candyDatas.m_candies[witchCandy], tile.transform);


                    tile.data.candyChildren = candy;

                }
            }
        }
    }



    public bool isEmpty()
    {
        for (int v = 0; v < m_gridManager.MaxRow; v++)
        {
            for (int i = 0; i < m_gridManager.MaxColumn; i++)
            {
                if (m_gridManager.MapTiles[new Vector2Int(v, i)].data.candyChildren == null)
                {

                    return true;

                }
            }
        }

        return false;
    }



        
    

}
