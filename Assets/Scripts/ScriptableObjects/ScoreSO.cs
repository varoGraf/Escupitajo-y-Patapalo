using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreSO", menuName = "ScriptableObjects/ScoreSO", order = 0)]
public class ScoreSO : ScriptableObject
{

    public int currentScore = 75;
    public int decreaseAmount = 25;
    public int increaseAmount = 25;

    public void increaseScore()
    {
        currentScore += increaseAmount;
    }

    public void decreaseScore()
    {
        currentScore -= decreaseAmount;
    }

    public void Reset()
    {
        currentScore = 75;
    }

}