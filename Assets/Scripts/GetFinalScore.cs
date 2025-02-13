using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetFinalScore : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    public int finalScore;

    // Start is called before the first frame update
    void Start()
    {
        finalScore = ScoreTracker.instance.score;
        finalScoreText.text = "You Collected " + finalScore.ToString() + " Buckets of Cereal!";
    }

}
