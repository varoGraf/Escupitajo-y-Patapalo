using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
public class DuelData
{
    [SerializeField]
    public TextAsset duelDataJSON;
    public Sentences sentencesInJSON;

    public void Setup(){
        sentencesInJSON = JsonUtility.FromJson<Sentences>(duelDataJSON.text);
        foreach (Sentence sentence in sentencesInJSON.sentences)
        {
            Debug.Log(sentence.Insulto + "->" + sentence.Respuesta);
        }
    }

    public void Randomize(){
        Sentence tempGO;
        for (int i = 0; i < sentencesInJSON.sentences.Length - 1; i++) 
          {
              int rnd = Random.Range(i, sentencesInJSON.sentences.Length);
              tempGO = sentencesInJSON.sentences[rnd];
              sentencesInJSON.sentences[rnd] = sentencesInJSON.sentences[i];
              sentencesInJSON.sentences[i] = tempGO;
          }
    }
}

