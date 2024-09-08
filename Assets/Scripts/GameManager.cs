using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Initializing and declaring the variables and constant.
    public List<GameObject> targets;
    private const float SpawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    private int _score;
    
    
    // Start is called before the first frame update.
    private void Start()
    {
        UpdatedScore(0);
        StartCoroutine(SpawnTarget());
    }

    // Coroutine that handles the spawn logic.
    private IEnumerator SpawnTarget()
    {
        // Pauses the spawn process and chooses a random object from out list to instantiate.
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate);
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
}
