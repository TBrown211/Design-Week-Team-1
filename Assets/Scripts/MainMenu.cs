using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Text boxes
    public TextMeshProUGUI player1Ready;
    public TextMeshProUGUI player2Ready;
    // Player ready
    private bool isPlayer1Ready;
    private bool isPlayer2Ready;

    // Start is called before the first frame update
    void Start()
    {
        isPlayer1Ready = false;
        isPlayer2Ready = false;
        player1Ready.color = Color.red;
        player2Ready.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        // Player 1 ready up
        if (Input.GetKeyDown(KeyCode.W))
        {
            isPlayer1Ready = !isPlayer1Ready;
        }
        else if (Input.GetButtonDown("SubmitGamepadLeft"))
        {
            isPlayer1Ready = !isPlayer1Ready;
        }

        // Player 1 colour updating
        if (isPlayer1Ready) { player1Ready.color = Color.green; }
        else { player1Ready.color = Color.red; }


        // Player 2 ready up
        if (Input.GetButtonDown("Fire1"))
        {
            isPlayer2Ready = !isPlayer2Ready;
        }
        else if (Input.GetButtonDown("SubmitGamepadRight"))
        {
            isPlayer2Ready = !isPlayer2Ready;
        }

        // Player 2 colour updating
        if (isPlayer2Ready) { player2Ready.color = Color.green; }
        else { player2Ready.color = Color.red; }


        // Start the game if both players are ready
        if (isPlayer1Ready && isPlayer2Ready)
        {
            SceneManager.LoadScene("Main Game");
        }
    }
}
