using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TextPanel : MonoBehaviour
{
    public DuelDataSO duelData;
    public GameObject menuPanel;
    private string[] textToDisplay;
    private int index;
    public UnityEvent onSpace;
    private TextMeshProUGUI m_textMeshPro;

    void Start()
    {
        index = 0;
        m_textMeshPro = gameObject.GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();
        int numRand = Random.Range(0, duelData.getStartingSentence().Length);
        if (duelData.getTurn()) //If player's turn
        {
            textToDisplay = new string[2];
            textToDisplay[0] = duelData.getStartingSentence()[numRand].Insultador;
            textToDisplay[1] = "¡Insúltale!";
            m_textMeshPro.text = textToDisplay[index];
        }
        else                    //If Npc's turn
        {
            textToDisplay = new string[3];
            textToDisplay[0] = duelData.getStartingSentence()[numRand].Insultado;
            duelData.setNPCSentence(duelData.getRandomInsult());
            textToDisplay[1] = "Pirata: " + duelData.getNPCSentence();
            textToDisplay[2] = "¡Respóndele!";
            m_textMeshPro.text = textToDisplay[index];
        }
    }

    public void spacePressed()
    {
        bool finished = this.gameObject.GetComponent<TypeWriterEffect>().finished;

        if (finished)
        {
            duelData.npc.isSpeaking = false;
            if (index >= textToDisplay.Length - 1)
            {
                this.gameObject.GetComponent<TypeWriterEffect>().finished = false;
                menuPanel.SetActive(true);
                menuPanel.GetComponent<MenuButtonController>().Init();
                this.gameObject.SetActive(false);
            }
            else
            {
                index++;
                m_textMeshPro.text = textToDisplay[index];
                if (m_textMeshPro.text.Equals(textToDisplay[1]) && !duelData.getTurn())
                {
                    duelData.npc.isSpeaking = true;
                }
                this.gameObject.GetComponent<TypeWriterEffect>().finished = false;
                this.gameObject.GetComponent<TypeWriterEffect>().StartCoroutine(this.gameObject.GetComponent<TypeWriterEffect>().Start());
            }
        }
        else
        {
            m_textMeshPro.maxVisibleCharacters = m_textMeshPro.text.Length;
            this.gameObject.GetComponent<TypeWriterEffect>().finished = true;
        }

    }
}
