using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    // Initializing and declaring the constants and variables.
    private Rigidbody _targetRb;
    private GameManager _gameManager;
    private const float MinSpeed = 12.0f;
    private const float MaxSpeed = 16.0f;
    private const float MaxTorque = 10.0f;
    private const float XRange = 4.0f;
    private const float YSpawnPos = 2.0f;
    
    public int pointValue;
    public ParticleSystem explosionParticles;

    // Start is called before the first frame update
    private void Start()
    {
        // Gets the rigid body component.
        _targetRb = GetComponent<Rigidbody>();
        
        // Gains access to the GameManager script.
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Applies our random upwards force.
        _targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        // Applies a random rotation.
        _targetRb.AddTorque(RandomTorque(), ForceMode.Impulse);

        // Sets the starting position.
        _targetRb.position = RandomPos();
    }

    // Destroys the game object when the mouse is on it and the left mouse button gets pressed. Also increases the score.
    private void OnMouseDown()
    {
        Destroy(gameObject);
        _gameManager.UpdatedScore(pointValue);
        Instantiate(explosionParticles, transform.position, explosionParticles.transform.rotation);
    }

    // Destroys the target when ist collides with another object that has a trigger. Also activates game over.
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
        }
    }

    // Function randomizes the upwards directed force.
    private static Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(MinSpeed, MaxSpeed);
    }

    // Function randomizes the rotation values.
    private static Vector3 RandomTorque()
    {
        return new Vector3(
            Random.Range(-MaxTorque, MaxTorque),
            Random.Range(-MaxTorque, MaxTorque),
            Random.Range(-MaxTorque, MaxTorque)
            );
    }

    // Function randomizes the spawn position on the X and Y axis.
    private static Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-XRange, XRange), -YSpawnPos);
    }
}