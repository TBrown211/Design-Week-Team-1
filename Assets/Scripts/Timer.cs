using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public bool timerIsOn = false;
    [SerializeField]
    private float timeLeft; 

    // Start is called before the first frame update
    void Start()
    {
        timerIsOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimerText(timeLeft);
            }
            else
            {
                timerIsOn = false;
                timeLeft = 0;
                SceneManager.LoadScene("Game Over");
            }
        }

    }

    private void UpdateTimerText (float currentTime)
    {
        currentTime += 1;

        float min = Mathf.FloorToInt(currentTime / 60);
        float sec = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", min, sec);
    }
}
