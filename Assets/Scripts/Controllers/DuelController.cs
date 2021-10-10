using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelController : MonoBehaviour
{
    [SerializeField]
    public DuelDataSO duelData;
    [SerializeField]
    public ScoreSO score;

    void Awake()
    {
        duelData.Setup();
        score.Reset();
    }
    void OnEnable() {
        duelData.Randomize();
    }
}
