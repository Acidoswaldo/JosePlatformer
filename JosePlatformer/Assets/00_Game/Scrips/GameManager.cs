using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    int score;
    public static GameManager instance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] CanvasGroup gameOverScreen;
    public bool gameEnded;


    public void ScoreUpdate(int newValue)
    {
        score = newValue;
        scoreText.text = "Score: " + score;
        finalScoreText.text = "Final Score: " + score;

    }

    public int GetScore()
    {
        return score;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator EndGameSequence()
    {
        while (gameOverScreen.alpha < 1)
        {
            gameOverScreen.alpha += 0.1f;
            yield return new WaitForEndOfFrame();
        }
        gameOverScreen.interactable = true;
    }
    public void EndGame()

    {
        StartCoroutine(EndGameSequence());
    }

    private void Start()
    {
        gameOverScreen.alpha = 0;
        gameOverScreen.interactable = false;
    }
}
