using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreSO", menuName = "ScriptableObjects/ScoreSO", order = 0)]
public class ScoreSO : ScriptableObject {

    [SerializeField]
    int currentScore=75;
    [SerializeField]
    int decreaseAmount=25;
    [SerializeField]
    int increaseAmount=25;

    public void increaseScore(){
        currentScore+=increaseAmount;
    }

    public void decreaseScore(){
        currentScore-=decreaseAmount;
    }

    public void Reset()
    {
        currentScore = 0;
    }

}