using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyController : MonoBehaviour
{

    GridManager gridManager;

    public CandyData candyDatas;

    // Start is called before the first frame update
    void Start()
    {
        gridManager = GameManager.instance.gridManager;

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ciao()
    {
        for (int row = 0; row < gridManager.maxRow; row++)
        {
            for (int column = 0; column < gridManager.maxColumn; column++)
            {

                int witchCandy = Random.Range(0, candyDatas.candies.Count);

                
                Candy candy = Instantiate(candyDatas.candies[witchCandy]);
                gridManager.mapTiles[new Vector2Int(row, column)].candyParent = candy;
                //candy.transform.SetParent()



            }

        }
    }

}
