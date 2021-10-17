using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    public TextMeshProUGUI m_textMeshPro;
    public bool finished;
    public int totalVisibleCharacters;

    public IEnumerator Start()
    {
        finished = false;
        m_textMeshPro = gameObject.GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();

        totalVisibleCharacters = m_textMeshPro.text.Length;
        int counter = 0;

        while (!finished)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);

            m_textMeshPro.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
            {
                finished = true;
            }
            counter += 1;
            yield return new WaitForSeconds(0.05f);
        }
    }

}
