using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckComboManager : MonoBehaviour
{


    GridManager gridManager;
    CandyController CandyController;


    public List<Candy> CandiesStored = new List<Candy>();
    public List<Candy> ListaCOMBOROW = new List<Candy>();
    public List<Candy> DEBUG = new List<Candy>();

    
   

    private void Awake()
    {
        gridManager = GameManager.instance.gridManager;
        CandyController = GameManager.instance.candyController;
    }


    public void FindRowCombination()
    {
        for (int v = 0; v < gridManager.maxRow; v++)
        {
            for (int i = 0; i < gridManager.maxColumn; i++)
            {
                Candy currentCandy = CandyController.GetCandys(v, i);

                CandiesStored.Add(currentCandy);

               


            }    
        }
       
    }

    public void FindColCombination()
    {
        for (int v = 0; v < gridManager.maxColumn; v++)
        {
            for (int i = 0; i < gridManager.maxRow; i++)
            {
                Candy currentCandy = CandyController.GetCandys(i, v);

                CandiesStored.Add(currentCandy);

            }
        }
    }



    

    public void RowCombo()
    {
        int v = -1;
        for (int i = 0; i < CandiesStored.Count; i++)
        {
            v += 1;
            if (i == 0) continue;

            if (CandiesStored[i].ID == CandiesStored[i - 1].ID)
            {
                ListaCOMBOROW.Add(CandiesStored[i - 1]);
            }
            else
            {
                if (ListaCOMBOROW.Count >= 2)
                {
                    ListaCOMBOROW.Add(CandiesStored[i - 1]);
                    DEBUG.AddRange(ListaCOMBOROW);
                    ListaCOMBOROW.Clear();
                }
                else ListaCOMBOROW.Clear();
            }

            if (v == gridManager.maxColumn )
            {
                if (ListaCOMBOROW.Count >= 3)
                {
                    DEBUG.AddRange(ListaCOMBOROW);

                    v = 0;
                }
                else
                {
                    ListaCOMBOROW.Clear();
                    v = 0;
                }

            }

        }
        //Destroyer(DEBUG);
        //ListaCOMBOROW.Clear();
        //DEBUG.Clear();
    }




    public void Destroyer(List<Candy> candies)
    {
        for(int i =0; i < candies.Count; i++)
        {
            Destroy(candies[i].gameObject);
        }
    }




}
