using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public void Increment(int inc = 1) {
        score += inc;
        Display();
    }

    void Display() {
        scoreText.text = "Score : " + score.ToString();
    }
}
