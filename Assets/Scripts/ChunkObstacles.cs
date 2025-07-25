using UnityEngine;
using System;
using System.Collections.Generic;
using Random = System.Random;

public class ChunkObstacles : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    private float[] lanes = { -2.5f, 0f, 2.5f };
    [SerializeField] private GameObject[] preFabList;
    private int amountOfObstacles;
    private int testInt;
    private float appleSpawnChance = 0.3f;

    List<int> availableLanes = new List<int> { 0, 1, 2 };
    
    void Start()
    {
        SpawnFence();
        SpawnApples();
    }

    private void SpawnFence()
    {
        int fencesToSpawn = UnityEngine.Random.Range(0, lanes.Length); // this statement chooses which lanes will have something in it

        for (int i = 0; i < fencesToSpawn; i++) // max index from 0 - 3
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
        
        int applesToSpawn = 1;

        for (int i = 0; i < applesToSpawn; i++)
        {
            int randomLaneIndex = UnityEngine.Random.Range(0, availableLanes.Count);
            int selectedLane = availableLanes[randomLaneIndex];
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);


            for (int j = 0; j < 3; j++)
            {
                Instantiate(applePrefab, new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z + (j - 2) * 2), Quaternion.identity, this.transform);
            }

            // for (i = 0; i < 2; i++)
            // {
            //     //
            // }


        }
    }
    
}

