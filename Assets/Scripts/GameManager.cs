using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Initializing the variable.
    public List<GameObject> targets;
    private const float SpawnRate = 1.0f;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate);
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }   
    }
}
