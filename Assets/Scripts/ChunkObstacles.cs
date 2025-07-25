using UnityEngine;
using System;
using System.Collections.Generic;
using Random = System.Random;

public class ChunkObstacles : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] private GameObject[] preFabList;
    
    private float[] lanes = { -2.5f, 0f, 2.5f };
    private int amountOfObstacles;
    private int testInt;
    private float appleSpawnChance = 0.3f;
    private float coinSpawnChance = 0.3f;

    List<int> availableLanes = new List<int> { 0, 1, 2 };
    
    void Start()
    {
        SpawnFence();
        SpawnApples();
        SpawnCoins();
    }

    private void SpawnFence()
    {
        int fencesToSpawn = UnityEngine.Random.Range(0, lanes.Length); // this statement chooses which lanes will have something in it

        for (int i = 0; i < fencesToSpawn; i++) // max index from 0 to 3
        {
            int randomLaneIndex = UnityEngine.Random.Range(0, availableLanes.Count); // avaialble lanes here is 3 on first iteration and less each iteration
            int selectedLane = availableLanes[randomLaneIndex]; // this picks the lane based on a random number between zero and how many lanes left.
            availableLanes.RemoveAt(randomLaneIndex);
            
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }

    }

    void SpawnApples()
    {
        if (appleSpawnChance > UnityEngine.Random.value) return;
        
        int randomLaneIndex = UnityEngine.Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        int applesPerBlock = UnityEngine.Random.Range(0, 3);
        
        for (int j = 0; j < applesPerBlock; j++)
        {
            Instantiate(applePrefab, new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z + (j - 2) * 2), Quaternion.identity, this.transform);
        }
    }
    
    void SpawnCoins()
    {
        if (coinSpawnChance > UnityEngine.Random.value) return;
        
        int randomLaneIndex = UnityEngine.Random.Range(0, availableLanes.Count);
        
        if (availableLanes.Count == 0) return;
        
        int selectedLane = availableLanes[0];
        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        
        int coinsPerBlock = UnityEngine.Random.Range(0, 3);
        for (int j = 0; j < coinsPerBlock; j++)
        {
            Instantiate(coinPrefab, new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z + (j - 2) * 2), Quaternion.identity, this.transform);
        }
    }
}

