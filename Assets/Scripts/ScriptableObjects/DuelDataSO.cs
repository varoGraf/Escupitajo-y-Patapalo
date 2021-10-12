using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



[System.Serializable]
public class Sentence
{
    public string Insulto;
    public string Respuesta;
}

[System.Serializable]
public class Sentences
{
    public Sentence[] sentences;
}

[System.Serializable]
[CreateAssetMenu(fileName = "DuelDataSO", menuName = "ScriptableObjects/DuelDataSO", order = 1)]
public class DuelDataSO : ScriptableObject
{
    public TextAsset duelDataJSON;
    public Sentences sentencesInJSON;
    public PirateSO player, npc;
    public UnityEvent onPlayerPoint, onNPCPoint;

    public void Setup()
    {
        sentencesInJSON = JsonUtility.FromJson<Sentences>(duelDataJSON.text);
    }

    public void Randomize()
    {
        Sentence tempGO;
        for (int i = 0; i < sentencesInJSON.sentences.Length - 1; i++)
        {
            int rnd = Random.Range(i, sentencesInJSON.sentences.Length);
            tempGO = sentencesInJSON.sentences[rnd];
            sentencesInJSON.sentences[rnd] = sentencesInJSON.sentences[i];
            sentencesInJSON.sentences[i] = tempGO;
        }
    }

    public string getRandomInsult()
    {
        int numRand = Random.Range(0, sentencesInJSON.sentences.Length);
        return sentencesInJSON.sentences[numRand].Insulto;
    }

    public string getRandomAnswer()
    {
        int numRand = Random.Range(0, sentencesInJSON.sentences.Length);
        return sentencesInJSON.sentences[numRand].Respuesta;
    }


    public bool Argument(string insulto, string respuesta)
    {
        bool result = false;
        foreach (Sentence sentence in sentencesInJSON.sentences)
        {
            if (insulto.Equals(sentence.Insulto))
            {
                if (respuesta.Equals(sentence.Respuesta)) result = true;
                break;
            }
        }
        return result;
    }

    public void playerInsult(string insulto, string respuesta)
    {
        if (Argument(insulto, respuesta)) { onNPCPoint.Invoke(); }
        else { onPlayerPoint.Invoke(); }
    }

    public void npcInsult(string insulto, string respuesta)
    {
        if (Argument(insulto, respuesta)) { onPlayerPoint.Invoke(); }
        else { onNPCPoint.Invoke(); }
    }

    public Sentence[] getSentences()
    {
        return sentencesInJSON.sentences;
    }
}

