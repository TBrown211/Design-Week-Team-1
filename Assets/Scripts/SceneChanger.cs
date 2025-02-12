using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    private void Update()
    {
        StartGame();
        MainMenu();
    }

    public void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main Game");
        }

    }

    public void MainMenu()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void QuitGame()
    {

    }


}
