using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckComboManager : MonoBehaviour
{


    GridManager gridManager;
    CandyController CandyController;

    private List<Candy> CandiesStoredRowCombination = new List<Candy>();
    [HideInInspector]
    public List<Candy> CombosRowList = new List<Candy>();
    private List<Candy> CandiesStoredColumnCombination = new List<Candy>();
    [HideInInspector]
    public List<Candy> CombosColumnList = new List<Candy>();
    public List<Candy> AllCombos = new List<Candy>();

    private void Awake()
    {
        gridManager = GameManager.instance.gridManager;
        CandyController = GameManager.instance.candyController;
    }



    public void StoreCandiesForRowCombination()
    {
        for (int v = 0; v < gridManager.maxRow; v++)
        {
            for (int i = 0; i < gridManager.maxColumn; i++)
            {
                Candy currentCandy = CandyController.GetCandys(v, i);

                CandiesStoredRowCombination.Add(currentCandy);

            }    
        }
       
    }

    public void StoreCandiesForColumnCombination()
    {
        for (int v = 0; v < gridManager.maxColumn; v++)
        {
            for (int i = 0; i < gridManager.maxRow; i++)
            {
                Candy currentCandy = CandyController.GetCandys(i, v);

                CandiesStoredColumnCombination.Add(currentCandy);

            }
        }
    }


    public void RowCombo()
    {
        int v = -1;
        for (int i = 0; i < CandiesStoredRowCombination.Count; i++)
        {
            v += 1;
            if (i == 0) continue;

            if (CandiesStoredRowCombination[i].ID == CandiesStoredRowCombination[i - 1].ID)
            {
                CombosRowList.Add(CandiesStoredRowCombination[i - 1]);
            }
            else
            {
                if (CombosRowList.Count >= 2)
                {
                    CombosRowList.Add(CandiesStoredRowCombination[i - 1]);
                    AllCombos.AddRange(CombosRowList);
                    CombosRowList.Clear();
                }
                else CombosRowList.Clear();
            }

            if (v == gridManager.maxColumn)
            {
                if (CombosRowList.Count >= 3)
                {
                    AllCombos.AddRange(CombosRowList);
                    v = 0;
                }
                else
                {
                    CombosRowList.Clear();
                    v = 0;
                }

            }

        }

    }


    public void ColumnCombo()
    {
        int v = -1;
        for (int i = 0; i < CandiesStoredColumnCombination.Count; i++)
        {
            v += 1;

            if (i == 0) continue;

            if (CandiesStoredColumnCombination[i].ID == CandiesStoredColumnCombination[i - 1].ID)
            {
                CombosColumnList.Add(CandiesStoredColumnCombination[i - 1]);
            }
            else
            {
                if (CombosColumnList.Count >= 2)
                {
                    CombosColumnList.Add(CandiesStoredColumnCombination[i - 1]);
                    AllCombos.AddRange(CombosColumnList);
                    CombosColumnList.Clear();
                }
                else CombosColumnList.Clear();
            }

            if (v == gridManager.maxRow)
            {
                if (CombosColumnList.Count >= 3)
                {
                    AllCombos.AddRange(CombosColumnList);
                    v = 0;
                }
                else
                {
                    CombosColumnList.Clear();
                    v = 0;
                }

            }

        }
        
    }


   
    public void ListClear()
    {
        CombosColumnList.Clear();
        CandiesStoredColumnCombination.Clear();
        CombosRowList.Clear();
        CandiesStoredRowCombination.Clear();
        AllCombos.Clear();
        

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
