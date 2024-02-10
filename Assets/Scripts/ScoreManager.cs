using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int score = 0;
    public TextMeshProUGUI scoreText;
    private void OnEnable()
    {
        // Souscrire à un abonnement
        Enemy.OnEnemyDeath += Increment;
        Coin.OnCoinCollected += Increment;
    }

    private void OnDisable()
    {
        // Se désabonner
        Enemy.OnEnemyDeath -= Increment;
        Coin.OnCoinCollected -= Increment;
    }

    public void Increment() {
        score += 1;
        Display();
    }

    void Display() {
        scoreText.text = "Score : " + score.ToString();
    }
}
