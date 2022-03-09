using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score scoreTxt;
    public Text textBox;
    public Text resultTextBox;
    int playerScore = 0;
    int enemyScore = 0;

    void Awake()
    {
        scoreTxt = this;
    }

    void Update()
    {
        textBox.text = playerScore + ":" + enemyScore;
    }

    public void AddPlayerPoint()
    {
        playerScore++;
        CheckResult();
    }

    public void AddEnemyPoint()
    {
        enemyScore++;
        CheckResult();
    }

    private void CheckResult()
    {
        if (playerScore >= 11 && Math.Abs(playerScore - enemyScore) > 1) {
                GameManager.GameMng.GameOver();
                resultTextBox.text = "You win!"; }

        else if (enemyScore >= 11 && Math.Abs(playerScore - enemyScore) > 1) {
                GameManager.GameMng.GameOver();
                resultTextBox.text = "You lose!"; }

        else {
            GameManager.GameMng.NewRound(); }
    }
}
