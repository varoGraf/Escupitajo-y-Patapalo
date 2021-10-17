using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStartController : MonoBehaviour
{
    public int index = 0;
    public int maxIndex = 1;
    [SerializeField] bool keyDown;
    [SerializeField] RectTransform rectTransform;
    public bool isPressUp, isPressDown, isPressConfirm;
    public AudioSource audio, audio1;
    int VerticalMovement;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        isPressUp = isPressDown = isPressConfirm = false;
    }


    public void onPressUp()
    {
        isPressUp = true;
    }

    public void onReleaseUp()
    {
        isPressUp = false;
    }

    public void onPressDown()
    {
        isPressDown = true;
    }

    public void onReleaseDown()
    {
        isPressDown = false;
    }

    public void onPressConfirm()
    {
        isPressConfirm = true;
    }

    public void onReleaseConfirm()
    {
        isPressConfirm = false;
    }

    void Update()
    {
        if (isPressUp) VerticalMovement = 1;
        if (isPressDown) VerticalMovement = -1;
        if (!isPressUp && !isPressDown) VerticalMovement = 0;
        if (Input.GetButtonDown("Space"))
        {
            audio1.Play();
            isPressConfirm = true;
        }
        Debug.Log(index);


        if (Input.GetAxis("Vertical") != 0 || VerticalMovement != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0 || VerticalMovement < 0)
                {
                    Debug.Log("Recoge input");
                    if (index < maxIndex)
                    {
                        index++;
                        audio.Play();
                        if (index > 1 && index < maxIndex)
                        {
                            rectTransform.offsetMax -= new Vector2(0, -64);
                        }
                    }

                }
                else if (Input.GetAxis("Vertical") > 0 || VerticalMovement > 0)
                {

                    if (index > 0)
                    {
                        index--;
                        audio.Play();
                        if (index < maxIndex - 1 && index > 0)
                        {
                            rectTransform.offsetMax -= new Vector2(0, 64);
                        }
                    }
                }

                keyDown = true;
            }
        }
        else
        {
            keyDown = false;
        }
    }
}