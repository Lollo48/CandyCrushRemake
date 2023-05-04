using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridControllerManager : MonoBehaviour
{

    public Transform m_firstClick;
    public Transform m_secondClick;

    [HideInInspector]
    public Transform m_target1;
    [HideInInspector]
    public Transform m_target2;
    

    public void SaveClickPosition(Transform target)
    {
        if (m_firstClick == null)
        {
            m_firstClick = target;
            m_target1 = target;
        }
        else
        {
            m_secondClick = target;
            m_target2 = target;
        }
    }

    public void EmptyClickPosition()
    {
        m_firstClick = null;
        m_secondClick = null;


    }

 

    public bool CanSwap()
    {
        Tile FirstClickedTile = m_firstClick.GetComponent<Tile>();
        Tile SecondClickedTile = m_secondClick.GetComponent<Tile>();

        if (FirstClickedTile.data.column == SecondClickedTile.data.column)
        {
            if (Mathf.Abs(FirstClickedTile.data.row - SecondClickedTile.data.row) == 1)
            {
                
                return true;
            }
            else
            {

                return false;
            }

        }
        else if (FirstClickedTile.data.row == SecondClickedTile.data.row)
        {
            if (Mathf.Abs(FirstClickedTile.data.column - SecondClickedTile.data.column) == 1 )
            {
                
                return true;
            }
            else
            {

                return false;

            }

        }
        else
        {

            return false;
        }


    }

    


    public void SwapCandys(Transform Parent1, Transform Parent2)
    {

        var candy1 = Parent1.GetComponentInChildren<Candy>();

        var candy2 = Parent2.GetComponentInChildren<Candy>();

        candy1.transform.SetParent(Parent2,false);

        candy2.transform.SetParent(Parent1,false);

        Parent1.GetComponent<Tile>().data.candyChildren = candy2;

        Parent2.GetComponent<Tile>().data.candyChildren = candy1;

    }
    

    public IEnumerator SwapCandyesWithLerp (Transform Parent1, Transform Parent2)
    {
        int duration = 10;
        float time = 0;
        //float time1 = 0;
        while (time < duration)
        {
            Parent1.position = Vector2.Lerp(Parent1.position, Parent2.position, time / duration);
            time += Time.deltaTime;
            yield return null;

        }
        Parent1.position = Parent2.position;
        //while (time1 < duration)
        //{
        //    Parent2.position = Vector2.Lerp(Parent2.position, Parent1.position, time1 / duration);
        //    time1 += Time.deltaTime;
        //    yield return new WaitForEndOfFrame();

        //}
       
    }






}
