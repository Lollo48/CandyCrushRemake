using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyController : MonoBehaviour
{

    GridManager gridManager;

    public CandyData candyDatas;

    private int IDcandyToSkipVertical;
    private int IDcandyToSkipHorizzontal;


 

    // Start is called before the first frame update
    void Awake()
    {
        gridManager = GameManager.instance.gridManager;
        CandySpawn();

    }



    public void CandySpawn()
    {
        for (int row = 0; row < gridManager.maxRow; row++)
        {
            for (int column = 0; column < gridManager.maxColumn; column++)
            {
                
                Tile tile = gridManager.mapTiles[new Vector2Int(row, column)];

                int witchCandy = Random.Range(0, candyDatas.candies.Count);

                if (choseCandy(row, column))
                {
                    while (witchCandy==IDcandyToSkipVertical || witchCandy == IDcandyToSkipHorizzontal) witchCandy = Random.Range(0, candyDatas.candies.Count);
                }

                Candy candy = Instantiate(candyDatas.candies[witchCandy],tile.transform);
                

                tile.data.candyChildren = candy;

            }

        }
    }


    public Candy GetCandys(int row, int column)
    {

        if (column < 0 || column >= gridManager.maxColumn || row < 0 || row >= gridManager.maxRow)
        {
            //Debug.Log("CandyNotFound");
            return null;
        }
        else
        {
            Candy candy1 = gridManager.mapTiles[new Vector2Int(row, column)].data.candyChildren;
            //Debug.Log("candy" + candy1);
            return candy1;
        }
       
    }

    bool choseCandy(int row,int column)
    {
        IDcandyToSkipHorizzontal = -1; //valore null 
        IDcandyToSkipVertical = -1;

        //Choose what sprite to use for this cell
        Candy right1 = GetCandys(row , column - 1);
        Candy right2 = GetCandys(row , column - 2);
        
        if (right2 != null && right1.ID == right2.ID) 
        {
            IDcandyToSkipHorizzontal = right2.ID;


        }

        //Choose what sprite to use for this cell
        Candy up1 = GetCandys(row - 1, column );
        Candy up2 = GetCandys(row - 2, column ); 
        if (up2 != null && up1.ID == up2.ID) 
        {
            IDcandyToSkipVertical = up2.ID;


        }
        if (IDcandyToSkipVertical != -1 || IDcandyToSkipHorizzontal != -1) return true;

        return false;


    }

}
