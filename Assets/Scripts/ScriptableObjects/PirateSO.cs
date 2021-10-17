using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PirateSO", menuName = "ScriptableObjects/PirateSO", order = 0)]
public class PirateSO : ScriptableObject
{
    public string pirateName = "Pirate";
    public Sprite standingSprite, headStandingSprite;
    public RuntimeAnimatorController anim;
    public bool isSpeaking = false;

    public Sprite GetStandingSprite()
    {
        return standingSprite;
    }
    public Sprite GetHeadStandingSprite()
    {
        return headStandingSprite;
    }
}
