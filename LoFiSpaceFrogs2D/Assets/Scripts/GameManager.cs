using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText; // Reference to the UI text element



    void Start()
    {
        UpdateScoreText(); // Update the UI text when the game starts
    }

    public void IncreaseScore()
    {
        score++; // Increment the score
        Debug.Log("Score: " + score);
        UpdateScoreText(); // Updateo el UI
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the UI text to display the current score
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }
}
