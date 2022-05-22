using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsTextController : MonoBehaviour
{

    public TextMeshProUGUI cashText, livesText, roundText;
    private int currentCash, currentLives, currentRound;
    
    void Start()
    {
        currentCash = Globals.cash;
        currentLives = Globals.lives;
        currentRound = Globals.waveNum;
        cashText.text = "Cash: " + Globals.cash.ToString();
        livesText.text = "Lives: " + Globals.lives.ToString();
        roundText.text = "Round: " + Globals.waveNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.cash != currentCash) {
            currentCash = Globals.cash;
            cashText.text = "Cash: " + Globals.cash.ToString();
        }
        if (Globals.lives != currentLives) {
            Debug.Log("Updating Text...");
            currentLives = Globals.lives;
            livesText.text = "Lives: " + Globals.lives.ToString();
        }
        if (Globals.waveNum != currentRound) {
            Debug.Log("Updating Text...");
            currentRound = Globals.waveNum;
            roundText.text = "Round: " + Globals.waveNum.ToString();
        }
    }
}
