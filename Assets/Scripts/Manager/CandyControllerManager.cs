using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyControllerManager : MonoBehaviour
{

    GridManager gridManager;

    public CandyData m_candyDatas;

    private int IDcandyToSkipVertical;
    private int IDcandyToSkipHorizzontal;


    

    // Start is called before the first frame update
    void Awake()
    {
        gridManager = GameManager.instance.m_gridManager;
        CandiesSpawn();

    }



    public void CandiesSpawn()
    {
        for (int row = 0; row < gridManager.MaxRow; row++)
        {
            for (int column = 0; column < gridManager.MaxColumn; column++)
            {
                
                Tile tile = gridManager.MapTiles[new Vector2Int(row, column)];

                int witchCandy = Random.Range(0, m_candyDatas.m_candies.Count);

                if (choseCandy(row, column))
                {
                    while (witchCandy==IDcandyToSkipVertical || witchCandy == IDcandyToSkipHorizzontal) witchCandy = Random.Range(0, m_candyDatas.m_candies.Count);
                }

                Candy candy = Instantiate(m_candyDatas.m_candies[witchCandy],tile.transform);
                

                tile.data.candyChildren = candy;

            }

        }
    }


    public Candy GetCandies(int row, int column)
    {

        if (column < 0 || column >= gridManager.MaxColumn || row < 0 || row >= gridManager.MaxRow)
        {
            //Debug.Log("CandyNotFound");
            return null;
        }
        else
        {
            Candy candy1 = gridManager.MapTiles[new Vector2Int(row, column)].data.candyChildren;
            //Debug.Log("candy" + candy1);
            return candy1;
        }
       
    }

    public bool choseCandy(int row,int column)
    {
        IDcandyToSkipHorizzontal = -1; //valore null 
        IDcandyToSkipVertical = -1;

        //Choose what sprite to use for this cell
        Candy right1 = GetCandies(row , column - 1);
        Candy right2 = GetCandies(row , column - 2);
        
        if (right2 != null && right1.ID == right2.ID) 
        {
            IDcandyToSkipHorizzontal = right2.ID;


        }

        //Choose what sprite to use for this cell
        Candy up1 = GetCandies(row - 1, column );
        Candy up2 = GetCandies(row - 2, column ); 
        if (up2 != null && up1.ID == up2.ID) 
        {
            IDcandyToSkipVertical = up2.ID;


        }
        if (IDcandyToSkipVertical != -1 || IDcandyToSkipHorizzontal != -1) return true;

        return false;


    }

}
