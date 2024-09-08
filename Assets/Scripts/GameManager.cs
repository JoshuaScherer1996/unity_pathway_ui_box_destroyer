using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Initializing and declaring the variable and constant.
    public List<GameObject> targets;
    private const float SpawnRate = 1.0f;
    
    
    // Start is called before the first frame update
    private void Start()
    {
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
}
