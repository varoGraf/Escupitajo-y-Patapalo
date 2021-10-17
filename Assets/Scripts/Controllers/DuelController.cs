using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DuelController : MonoBehaviour
{
    public DuelDataSO duelData;
    public ScoreSO score;
    public UnityEvent onEndScore;

    void Awake()
    {
        duelData.Setup();
        score.Reset();
    }
    void OnEnable()
    {
        duelData.Randomize();
    }

    void Update()
    {
        if (score.currentScore <= 0 || score.currentScore >= 150)
        {
            onEndScore.Invoke();
        }
    }

    public void increaseScore()
    {
        score.increaseScore();
    }
    public void decreaseScore()
    {
        score.decreaseScore();
    }
}
