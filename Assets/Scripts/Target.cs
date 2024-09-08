using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    // Initializing and declaring the constants and variable.
    private Rigidbody _targetRb;
    private const float MinSpeed = 12.0f;
    private const float MaxSpeed = 16.0f;
    private const float MaxTorque = 10.0f;
    private const float XRange = 4.0f;
    private const float YSpawnPos = 2.0f;

    // Start is called before the first frame update
    private void Start()
    {
        // Gets the rigid body component.
        _targetRb = GetComponent<Rigidbody>();

        // Applies our random upwards force.
        _targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        // Applies a random rotation.
        _targetRb.AddTorque(RandomTorque(), ForceMode.Impulse);

        // Sets the starting position.
        _targetRb.position = RandomPos();
    }

    // Destroys the game object when the mouse is on it and the left mouse button gets pressed.
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    // Destroys the target when ist collides with another object that has a trigger.
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
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