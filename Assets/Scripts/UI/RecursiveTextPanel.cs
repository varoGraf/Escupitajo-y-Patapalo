using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class RecursiveTextPanel : MonoBehaviour
{
    public GameObject menuPanel;
    public DuelDataSO duelData;
    private TextMeshProUGUI m_textMeshPro;
    private string[] currentText;
    public UnityEvent onSpace;
    bool exit, auxBool;

    public void Init()
    {
        m_textMeshPro = gameObject.GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();
        currentText = new string[2];
        currentText[0] = "Tú: " + duelData.getPlayerSentence();
        m_textMeshPro.text = currentText[0];
        duelData.player.isSpeaking = true;
        this.gameObject.GetComponent<TypeWriterEffect>().finished = false;
        this.gameObject.GetComponent<TypeWriterEffect>().StartCoroutine(this.gameObject.GetComponent<TypeWriterEffect>().Start());
        exit = false;
        auxBool = false;
    }

    public void onSpacePressed()
    {
        bool finished = this.gameObject.GetComponent<TypeWriterEffect>().finished;
        if (finished)
        {
            duelData.npc.isSpeaking = false;
            duelData.player.isSpeaking = false;
            if (exit)
            {
                menuPanel.SetActive(true);
                menuPanel.GetComponent<MenuButtonController>().Init();
                this.gameObject.SetActive(false);
            }
            else
            {
                if (duelData.getTurn())
                {
                    duelData.setNPCSentence(duelData.getRandomAnswer());
                    currentText[1] = "Pirata: " + duelData.getNPCSentence();
                    m_textMeshPro.text = currentText[1];
                    duelData.npc.isSpeaking = true;
                    duelData.playerInsult(duelData.getPlayerSentence(), duelData.getNPCSentence());
                    if (duelData.getTurn()) { exit = true; }
                    else { exit = false; auxBool = true; }
                    this.gameObject.GetComponent<TypeWriterEffect>().finished = false;
                    this.gameObject.GetComponent<TypeWriterEffect>().StartCoroutine(this.gameObject.GetComponent<TypeWriterEffect>().Start());
                }
                else
                {
                    if (!auxBool)
                    {
                        duelData.npcInsult(duelData.getNPCSentence(), duelData.getPlayerSentence());
                        if (duelData.getTurn())
                        {
                            this.gameObject.GetComponent<TypeWriterEffect>().finished = false;
                            menuPanel.SetActive(true);
                            menuPanel.GetComponent<MenuButtonController>().Init();
                            this.gameObject.SetActive(false);
                        }
                        else
                        {
                            duelData.setNPCSentence(duelData.getRandomInsult());
                            currentText[1] = "Pirata: " + duelData.getNPCSentence();
                            m_textMeshPro.text = currentText[1];
                            duelData.npc.isSpeaking = true;
                            exit = true;
                            this.gameObject.GetComponent<TypeWriterEffect>().finished = false;
                            this.gameObject.GetComponent<TypeWriterEffect>().StartCoroutine(this.gameObject.GetComponent<TypeWriterEffect>().Start());
                        }
                    }
                    else
                    {
                        duelData.setNPCSentence(duelData.getRandomInsult());
                        currentText[1] = "Pirata: " + duelData.getNPCSentence();
                        m_textMeshPro.text = currentText[1];
                        duelData.npc.isSpeaking = true;
                        exit = true;
                        this.gameObject.GetComponent<TypeWriterEffect>().finished = false;
                        this.gameObject.GetComponent<TypeWriterEffect>().StartCoroutine(this.gameObject.GetComponent<TypeWriterEffect>().Start());
                    }
                }
            }

        }
        else
        {
            m_textMeshPro.maxVisibleCharacters = m_textMeshPro.text.Length;
            this.gameObject.GetComponent<TypeWriterEffect>().finished = true;
        }
    }
}
