using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuStartButton : MonoBehaviour
{
    public MenuStartController menuButtonController;
    public Animator animator;
    public int thisIndex;
    public UnityEvent onExit, onGoGame;

    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            if (menuButtonController.isPressConfirm)
            {
                animator.SetBool("pressed", true);
                if (this.thisIndex == 0)
                {
                    onGoGame.Invoke();
                }
                else
                {
                    onExit.Invoke();
                }
            }
            else if (animator.GetBool("pressed"))
            {
                animator.SetBool("pressed", false);
            }
        }
        else
        {
            animator.SetBool("selected", false);
        }
    }
}