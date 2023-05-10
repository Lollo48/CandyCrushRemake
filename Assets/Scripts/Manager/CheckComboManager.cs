using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckComboManager : MonoBehaviour
{


    GridManager m_gridManager;
    CandyControllerManager m_candyController;

    private List<Candy> m_candiesStoredRowCombination = new List<Candy>();
    private List<Candy> m_combosRowList = new List<Candy>();

    private List<Candy> m_candiesStoredColumnCombination = new List<Candy>();
    private List<Candy> m_combosColumnList = new List<Candy>();

    public List<Candy> AllCombos = new List<Candy>();


    private void Awake()
    {
        m_gridManager = GameManager.instance.m_gridManager;
        m_candyController = GameManager.instance.m_candyControllerManager;
    }

    public void StoreCandiesForRowCombination()
    {
        for (int v = 0; v < m_gridManager.MaxRow; v++)
        {
            for (int i = 0; i < m_gridManager.MaxColumn; i++)
            {
                Candy currentCandy = m_candyController.GetCandies(v, i);

                m_candiesStoredRowCombination.Add(currentCandy);

            }    
        }
       
    }

    public void StoreCandiesForColumnCombination()
    {
        for (int v = 0; v < m_gridManager.MaxColumn; v++)
        {
            for (int i = 0; i < m_gridManager.MaxRow; i++)
            {
                Candy currentCandy = m_candyController.GetCandies(i, v);

                m_candiesStoredColumnCombination.Add(currentCandy);

            }
        }
    }


    public void RowCombo()
    {
        int v = -1;
        for (int i = 0; i < m_candiesStoredRowCombination.Count; i++)
        {
            v += 1;
            if (i == 0) continue;

            if (m_candiesStoredRowCombination[i].ID == m_candiesStoredRowCombination[i - 1].ID)
            {
                m_combosRowList.Add(m_candiesStoredRowCombination[i - 1]);
            }
            else
            {
                if (m_combosRowList.Count >= 2)
                {
                    m_combosRowList.Add(m_candiesStoredRowCombination[i - 1]);
                    AllCombos.AddRange(m_combosRowList);
                    m_combosRowList.Clear();
                }
                else m_combosRowList.Clear();
            }

            if (v == m_gridManager.MaxColumn)
            {
                if (m_combosRowList.Count >= 3)
                {
                    AllCombos.AddRange(m_combosRowList);
                    v = 0;
                }
                else
                {
                    m_combosRowList.Clear();
                    v = 0;
                }

            }

        }

    }


    public void ColumnCombo()
    {
        int v = -1;
        for (int i = 0; i < m_candiesStoredColumnCombination.Count; i++)
        {
            v += 1;

            if (i == 0) continue;

            if (m_candiesStoredColumnCombination[i].ID == m_candiesStoredColumnCombination[i - 1].ID)
            {
                m_combosColumnList.Add(m_candiesStoredColumnCombination[i - 1]);
            }
            else
            {
                if (m_combosColumnList.Count >= 2)
                {
                    m_combosColumnList.Add(m_candiesStoredColumnCombination[i - 1]);
                    AllCombos.AddRange(m_combosColumnList);
                    m_combosColumnList.Clear();
                }
                else m_combosColumnList.Clear();
            }

            if (v == m_gridManager.MaxRow)
            {
                if (m_combosColumnList.Count >= 3)
                {
                    AllCombos.AddRange(m_combosColumnList);
                    v = 0;
                }
                else
                {
                    m_combosColumnList.Clear();
                    v = 0;
                }

            }

        }
        
    }


   
    public void ListClear()
    {
        m_combosColumnList.Clear();
        m_candiesStoredColumnCombination.Clear();
        m_combosRowList.Clear();
        m_candiesStoredRowCombination.Clear();
        AllCombos.Clear();
        

    }



    public void Destroyer(List<Candy> candies)
    {
        for(int i =0; i < candies.Count; i++)
        {
            
            Tile tile = candies[i].GetComponentInParent<Tile>();


            Destroy(candies[i].gameObject);

            tile.data.candyChildren = null;
        }
    }




}
