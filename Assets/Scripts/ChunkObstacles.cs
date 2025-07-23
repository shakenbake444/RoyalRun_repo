using UnityEngine;
using System;
using System.Collections.Generic;
using Random = System.Random;
using System.Linq;

public class ChunkObstacles : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] private float[] lanes = { -2.5f, 0f, 2.5f };
    [SerializeField] private GameObject[] preFabList;
    private int amountOfObstacles;
    private int[] shuffleArray = { 0, 1, 2 };
    private List<int> shuffleList;

    void Start()
    {
        SpawnFence();

        shuffleList = shuffleArray.ToList();

    }

    private void SpawnFence()
    {
        Shuffle(shuffleList);
        
        amountOfObstacles = UnityEngine.Random.Range(0, preFabList.Length);
        Debug.Log(amountOfObstacles);
        
        int randomLaneIndex = UnityEngine.Random.Range(0, lanes.Length);
        Vector3 spawnPosition = new Vector3(lanes[randomLaneIndex], transform.position.y, transform.position.z);
        Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
    }
    
    static void Shuffle<T>(List<T> list)
    {
        Random rng = new Random();
        int n = list.Count;

        for (int i = n - 1; i > 0; i--)
        {
            int k = rng.Next(i + 1); // 0 <= k <= i
            (list[i], list[k]) = (list[k], list[i]); // swap
        }
    }
    
}

//make a list of numbers of amountofObstacles in length
//shuffle the list
