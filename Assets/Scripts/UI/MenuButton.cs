using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public MenuButtonController menuButtonController;
    public Animator animator;
    public int thisIndex;
    public GameObject menuPanelToOpen;

    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            if (menuButtonController.isPressConfirm)
            {
                animator.SetBool("pressed", true);
                if (menuPanelToOpen != null)
                {
                    menuPanelToOpen.SetActive(true);
                    menuPanelToOpen.GetComponent<RecursiveTextPanel>().Init();
                    menuButtonController.gameObject.SetActive(false);
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
    public int getIndex()
    {
        return thisIndex;
    }

}
