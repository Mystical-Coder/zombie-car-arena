using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;

    public int score = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}