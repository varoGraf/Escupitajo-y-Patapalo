using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    int maximum, minimum, current;
    public Image mask;
    public ScoreSO score;
    float currentOffset;
    float maximumOffset;
    float fillAmount;
    float speed = 10f;

    void Start()
    {
        minimum = 0;
        maximum = 75 * 2;
        current = score.currentScore;
        currentOffset = current - minimum;
        maximumOffset = maximum - minimum;
        fillAmount = currentOffset / maximumOffset;
    }

    void Update()
    {
        if (current != score.currentScore)
        {
            current = score.currentScore;
            currentOffset = current - minimum;
            maximumOffset = maximum - minimum;
            fillAmount = currentOffset / maximumOffset;
        }
        mask.fillAmount = Mathf.Lerp(mask.fillAmount, fillAmount, Time.deltaTime * speed);

    }

}
