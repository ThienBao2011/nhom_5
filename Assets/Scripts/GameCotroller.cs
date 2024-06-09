using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCotroller : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int live = 4;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI liveText;
    // Start is called before the first frame update
    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameCotroller>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        liveText.text = live.ToString();
        scoreText.text = score.ToString();
    }
    public void AddCore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }
    private void DecreaseLive()
    {
        live--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        liveText.text = live.ToString();
    }
    private void resetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    public void ProcessPlayerDeath()
    {
        if (live > 1)
        {
            DecreaseLive();
        }
        else
        {
            resetGame();
        }
    }
    public int GetScore()
    {
        return score;
    }
}
