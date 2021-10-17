using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelController : MonoBehaviour
{
    public DuelDataSO duelData;
    public ScoreSO score;

    void Awake()
    {
        duelData.Setup();
        score.Reset();
    }
    void OnEnable()
    {
        duelData.Randomize();
    }

    public void increaseScore()
    {
        Debug.Log("Increased");
        score.increaseScore();
    }
    public void decreaseScore()
    {
        score.decreaseScore();
    }
}
