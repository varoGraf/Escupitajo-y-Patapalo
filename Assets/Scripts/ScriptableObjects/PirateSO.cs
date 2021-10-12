using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PirateSO", menuName = "ScriptableObjects/PirateSO", order = 0)]
public class PirateSO : ScriptableObject
{
    public string pirateName = "Pirate";
    public List<AnimationClip> animations;
    public Sprite standingSprite, headStandingSprite;
    public AnimationClip getAnimation(string name)
    {
        AnimationClip animationClip = null;
        foreach (AnimationClip clip in animations)
        {
            if (name.Equals(clip.name)) { animationClip = clip; break; }
        }
        return animationClip;
    }
    public Sprite GetStandingSprite()
    {
        return standingSprite;
    }
    public Sprite GetHeadStandingSprite()
    {
        return headStandingSprite;
    }
}
