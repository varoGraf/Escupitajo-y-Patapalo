using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelController : MonoBehaviour
{
    public DuelData duelData;

    void Awake()
    {
        duelData.Setup();
    }

    void OnEnable()
    {

    }
}
