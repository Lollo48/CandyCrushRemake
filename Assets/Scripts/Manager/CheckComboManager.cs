using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckComboManager : MonoBehaviour
{


    GridManager gridManager;
    CandyControllerManager candyController;

    private List<Candy> candiesStoredRowCombination = new List<Candy>();
    private List<Candy> combosRowList = new List<Candy>();

    private List<Candy> candiesStoredColumnCombination = new List<Candy>();
    private List<Candy> combosColumnList = new List<Candy>();

    public List<Candy> m_allCombos = new List<Candy>();

    private void Awake()
    {
        gridManager = GameManager.instance.m_gridManager;
        candyController = GameManager.instance.m_candyControllerManager;
    }

    public void StoreCandiesForRowCombination()
    {
        for (int v = 0; v < gridManager.m_maxRow; v++)
        {
            for (int i = 0; i < gridManager.m_maxColumn; i++)
            {
                Candy currentCandy = candyController.GetCandies(v, i);

                candiesStoredRowCombination.Add(currentCandy);

            }    
        }
       
    }

    public void StoreCandiesForColumnCombination()
    {
        for (int v = 0; v < gridManager.m_maxColumn; v++)
        {
            for (int i = 0; i < gridManager.m_maxRow; i++)
            {
                Candy currentCandy = candyController.GetCandies(i, v);

                candiesStoredColumnCombination.Add(currentCandy);

            }
        }
    }


    public void RowCombo()
    {
        int v = -1;
        for (int i = 0; i < candiesStoredRowCombination.Count; i++)
        {
            v += 1;
            if (i == 0) continue;

            if (candiesStoredRowCombination[i].ID == candiesStoredRowCombination[i - 1].ID)
            {
                combosRowList.Add(candiesStoredRowCombination[i - 1]);
            }
            else
            {
                if (combosRowList.Count >= 2)
                {
                    combosRowList.Add(candiesStoredRowCombination[i - 1]);
                    m_allCombos.AddRange(combosRowList);
                    combosRowList.Clear();
                }
                else combosRowList.Clear();
            }

            if (v == gridManager.m_maxColumn)
            {
                if (combosRowList.Count >= 3)
                {
                    m_allCombos.AddRange(combosRowList);
                    v = 0;
                }
                else
                {
                    combosRowList.Clear();
                    v = 0;
                }

            }

        }

    }


    public void ColumnCombo()
    {
        int v = -1;
        for (int i = 0; i < candiesStoredColumnCombination.Count; i++)
        {
            v += 1;

            if (i == 0) continue;

            if (candiesStoredColumnCombination[i].ID == candiesStoredColumnCombination[i - 1].ID)
            {
                combosColumnList.Add(candiesStoredColumnCombination[i - 1]);
            }
            else
            {
                if (combosColumnList.Count >= 2)
                {
                    combosColumnList.Add(candiesStoredColumnCombination[i - 1]);
                    m_allCombos.AddRange(combosColumnList);
                    combosColumnList.Clear();
                }
                else combosColumnList.Clear();
            }

            if (v == gridManager.m_maxRow)
            {
                if (combosColumnList.Count >= 3)
                {
                    m_allCombos.AddRange(combosColumnList);
                    v = 0;
                }
                else
                {
                    combosColumnList.Clear();
                    v = 0;
                }

            }

        }
        
    }


   
    public void ListClear()
    {
        combosColumnList.Clear();
        candiesStoredColumnCombination.Clear();
        combosRowList.Clear();
        candiesStoredRowCombination.Clear();
        m_allCombos.Clear();
        

    }



    public void Destroyer(List<Candy> candies)
    {
        for(int i =0; i < candies.Count; i++)
        {
            Tile tile = candies[i].GetComponentInParent<Tile>();
            
            Destroy(tile.data.candyChildren.gameObject);
            
        }
    }




}
