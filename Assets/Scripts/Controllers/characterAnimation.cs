using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnimation : MonoBehaviour
{
    public PirateSO character;
    Animator anim;

    void Start()
    {
        anim = this.transform.GetComponentInChildren<Animator>() ?? gameObject.AddComponent<Animator>();
        anim.runtimeAnimatorController = character.anim;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).name.Equals("Head"))
            {
                this.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = character.headStandingSprite;
            }
            else
            {
                this.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = character.standingSprite;
            }
        }
    }

    void Update()
    {
        if (character.isSpeaking)
        {
            anim.SetBool("isSpeaking", true);
        }
        else
        {
            anim.SetBool("isSpeaking", false);
        }
    }

}
