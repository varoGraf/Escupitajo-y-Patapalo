using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuButtonController : MonoBehaviour
{
    public int index;
    int maxIndex;
    public DuelDataSO duelData;
    int heightSentence = 30;
    Sentence[] sentences;
    public GameObject sentenceGUI;
    [SerializeField] bool keyDown;
    [SerializeField] RectTransform rectTransform;
    public GameObject menuPanelToOpen;
    public bool isPressUp, isPressDown, isPressConfirm;
    int VerticalMovement;
    bool turn;
    public AudioSource audio, audio1;

    public void Init()
    {
        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        rectTransform = GetComponent<RectTransform>();
        isPressUp = isPressDown = isPressConfirm = false;
        sentences = duelData.getSentences();
        maxIndex = sentences.Length - 1;
        turn = duelData.getTurn();
        if (turn)
        {
            for (int i = 0; i <= maxIndex; i++)
            {
                GameObject gameObject = Instantiate(sentenceGUI, Vector3.zero, Quaternion.identity, this.transform) as GameObject;
                gameObject.GetComponent<MenuButton>().menuButtonController = this;
                gameObject.GetComponent<MenuButton>().menuPanelToOpen = menuPanelToOpen;
                gameObject.GetComponent<MenuButton>().thisIndex = i;
                gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = sentences[i].Insulto;
            }
        }
        else
        {
            for (int i = 0; i <= maxIndex; i++)
            {
                GameObject gameObject = Instantiate(sentenceGUI, Vector3.zero, Quaternion.identity, this.transform) as GameObject;
                gameObject.GetComponent<MenuButton>().menuButtonController = this;
                gameObject.GetComponent<MenuButton>().menuPanelToOpen = menuPanelToOpen;
                gameObject.GetComponent<MenuButton>().thisIndex = i;
                gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = sentences[i].Respuesta;
            }
        }

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
            if (turn)
            {
                duelData.setPlayerSentence(sentences[index].Insulto);
            }
            else
            {
                duelData.setPlayerSentence(sentences[index].Respuesta);
            }

            isPressConfirm = true;
        }

        if (Input.GetAxis("Vertical") != 0 || VerticalMovement != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0 || VerticalMovement < 0)
                {
                    if (index < maxIndex)
                    {
                        index++;
                        audio.Play();
                        if (index > 3 && index < maxIndex)
                        {
                            rectTransform.offsetMax -= new Vector2(0, -heightSentence);
                        }
                    }

                }
                else if (Input.GetAxis("Vertical") > 0 || VerticalMovement > 0)
                {

                    if (index > 0)
                    {
                        index--;
                        audio.Play();
                        if (index < maxIndex - 1 && index > 2)
                        {
                            rectTransform.offsetMax -= new Vector2(0, heightSentence);
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
