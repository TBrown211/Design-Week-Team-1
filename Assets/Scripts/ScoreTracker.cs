using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public static ScoreTracker instance;

    public TextMeshProUGUI scoreText;

    public int score = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void AddPoint()
    {
        //Increase score
        score++;
        //Update the score text
        scoreText.text = score.ToString();
    }

}
