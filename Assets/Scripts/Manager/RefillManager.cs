using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillManager : MonoBehaviour
{
    GridManager gridManager;


    private void Awake()
    {
        gridManager = GameManager.instance.gridManager;
    }


    private void CheckForEmptyCandies()
    {
        for (int v = 0; v < gridManager.maxRow; v++)
        {
            for (int i = 0; i < gridManager.maxColumn; i++)
            {


            }
        }



    }





}
