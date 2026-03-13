using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float gameTime = 60f;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI fpsText;
    public GameObject endScreen;
    public TextMeshProUGUI finalScoreText;

    float timer;
    bool gameEnded = false;

    void Start()
    {
        Application.targetFrameRate = 60;
        timer = gameTime;
        endScreen.SetActive(false);
    }

    void Update()
    {
        if(!gameEnded)
        {
            UpdateTimer();
        }

        UpdateFPS();
    }

    void UpdateTimer()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = 0;
            EndGame();
        }

        timerText.text = "Time: " + Mathf.Ceil(timer).ToString();
    }

    void UpdateFPS()
    {
        float fps = 1f / Time.unscaledDeltaTime;
        fpsText.text = "FPS: " + Mathf.Round(fps).ToString();
    }

    void EndGame()
    {
        gameEnded = true;

        Time.timeScale = 0;

        endScreen.SetActive(true);

        finalScoreText.text = "Final Score: " + ScoreManager.instance.score;
    }

    public void RestartGame()
    {
        Debug.Log("Restart Clicked");

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}