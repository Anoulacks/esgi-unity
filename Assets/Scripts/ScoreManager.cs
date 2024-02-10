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
        // Souscrire à un Abonnement
        Enemy.OnEnemyDeath += Increment;
        ItemTarget.OnItemCollected += Increment;
    }

    private void OnDisable()
    {
        // Se désabonner
        Enemy.OnEnemyDeath -= Increment;
        ItemTarget.OnItemCollected -= Increment;
    }

    public void Increment() {
        score += 1;
        Display();
    }

    void Display() {
        scoreText.text = "Score : " + score.ToString();
    }
}
