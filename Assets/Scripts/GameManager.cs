using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Initializing and declaring the variables.
    public List<GameObject> targets;
    private float _spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int _score;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;

    // Function stets all necessary states for the scene when the game starts.
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        UpdatedScore(0);
        StartCoroutine(SpawnTarget());
        titleScreen.SetActive(false);
        _spawnRate /= difficulty;
    }
    
    // Coroutine that handles the spawn logic.
    private IEnumerator SpawnTarget()
    {
        // Pauses the spawn process and chooses a random object from out list to instantiate.
        while (isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    // Function increases the score with the provided argument when it is invoked.
    public void UpdatedScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = "Score: " + _score;
    }

    // Function enables the game over text.
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false; 
    }

    // Function reloads the currently active scene.
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
