using System;
using UnityEngine;

public class ChunkPrefabScript : MonoBehaviour

{
    [SerializeField] private int chunkSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveChunkPrefab()
    {
        transform.position += Vector3.back * chunkSpeed * Time.deltaTime;
    }
}
