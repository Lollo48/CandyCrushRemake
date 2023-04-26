using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Candy Data", menuName = "Candy Data")]

public class CandyData : ScriptableObject
{
    public List<Candy> candies = new List<Candy>(); 
    

}
