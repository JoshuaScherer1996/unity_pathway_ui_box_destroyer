using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // Declaring the variables.
    private Button _button;
    private GameManager _gameManager;
    public int difficulty;
    
    // Start is called before the first frame update.
    private void Start()
    {
        // Loads all important components into the file.
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Function sets the difficulty for the game.
    private void SetDifficulty()
    {
       _gameManager.StartGame(difficulty);
    }
}
