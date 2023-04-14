using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ghostPrefab;
    private float spawnRangeX = 430.0f;
    private float spawnInterval = 1.5f;
    private float startDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Prevents ghosts from spawning at the location of the player or in an island

        if (!CompareTag("Player") && !CompareTag("Island"))
        {
            InvokeRepeating("SpawnGhost", startDelay, spawnInterval);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnGhost()
    {
        int spawnRangeY = Random.Range(0, 20);
        Vector3 spawnPos = new Vector3(Random.Range(11, spawnRangeX), spawnRangeY, 2.08f);
        Instantiate(ghostPrefab, spawnPos, ghostPrefab.transform.rotation);
    }
}
