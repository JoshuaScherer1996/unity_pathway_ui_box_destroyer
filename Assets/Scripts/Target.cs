using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _targetRb;
    
    // Start is called before the first frame update
    private void Start()
    {
        // Gets the rigid body component.
        _targetRb = GetComponent<Rigidbody>();
        
        // Applies our random upwards force.
        _targetRb.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
        
        // Applies a random rotation.
        _targetRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);

        // Sets the starting position.
        _targetRb.position = new Vector3(Random.Range(-4, 4), -6);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
