using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PirateSO", menuName = "ScriptableObjects/PirateSO", order = 0)]
public class PirateSO : ScriptableObject
{
    public string pirateName = "Pirate";
    public List<AnimationClip> animations;
    public AnimationClip getAnimation(string name)
    {
        AnimationClip animationClip = null;
        foreach (AnimationClip clip in animations)
        {
            if (clip.name.Equals(name)) animationClip = clip; break;
        }
        return animationClip;
    }
}
