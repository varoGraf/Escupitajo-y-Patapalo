using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextEnd : MonoBehaviour
{
    public ScoreSO score;
    private TextMeshProUGUI m_textMeshPro;

    void Start()
    {
        m_textMeshPro = gameObject.GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();
        if (score.currentScore <= 0)
        {
            m_textMeshPro.text = "¡Has perdido!.\n ¿Quieres volver a jugar?";
        }
        if (score.currentScore >= 150)
        {
            m_textMeshPro.text = "¡Has ganado!.\n ¿Quieres volver a jugar?";
        }
        if (score.currentScore > 0 && score.currentScore < 150)
        {
            m_textMeshPro.text = "Todavía no has jugado.\n ¿Quieres jugar?";
        }

    }
}
