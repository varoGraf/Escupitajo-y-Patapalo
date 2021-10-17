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
public class StartSentence
{
    public string Insultado;
    public string Insultador;
}

[System.Serializable]
public class StartingSentences
{
    public StartSentence[] startingSentences;
}

[System.Serializable]
[CreateAssetMenu(fileName = "DuelDataSO", menuName = "ScriptableObjects/DuelDataSO", order = 1)]
public class DuelDataSO : ScriptableObject
{
    public TextAsset duelDataJSON, startingJSON;
    public Sentences sentencesInJSON;
    public StartingSentences startingSentencesJSON;
    public PirateSO player, npc;
    public UnityEvent onPlayerPoint, onNPCPoint;
    private string playerSentence, npcSentence;
    private bool turn;//turn=true=player ; turn=false=npc ;

    public void Setup()
    {
        sentencesInJSON = JsonUtility.FromJson<Sentences>(duelDataJSON.text);
        startingSentencesJSON = JsonUtility.FromJson<StartingSentences>(startingJSON.text);
        if (Random.Range(0, 2) == 0)
        {
            turn = true;
        }
        else { turn = false; }
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

    public string getRandomInsultado()
    {
        int numRand = Random.Range(0, startingSentencesJSON.startingSentences.Length);
        return startingSentencesJSON.startingSentences[numRand].Insultado;
    }

    public string getRandomInsultador()
    {
        int numRand = Random.Range(0, startingSentencesJSON.startingSentences.Length);
        return startingSentencesJSON.startingSentences[numRand].Insultador;
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
        if (Argument(insulto, respuesta)) { onNPCPoint.Invoke(); turn = false; }
        else { onPlayerPoint.Invoke(); turn = true; }
    }

    public void npcInsult(string insulto, string respuesta)
    {
        if (Argument(insulto, respuesta)) { onPlayerPoint.Invoke(); turn = true; }
        else { onNPCPoint.Invoke(); turn = false; }
    }

    public Sentence[] getSentences()
    {
        return sentencesInJSON.sentences;
    }

    public StartSentence[] getStartingSentence()
    {
        return startingSentencesJSON.startingSentences;
    }

    public bool getTurn()
    {
        return turn;
    }

    public void setPlayerSentence(string sentenceCh)
    {
        playerSentence = sentenceCh;
    }

    public void setNPCSentence(string sentenceCh)
    {
        npcSentence = sentenceCh;
    }

    public string getPlayerSentence()
    {
        return playerSentence;
    }
    public string getNPCSentence()
    {
        return npcSentence;
    }

}

