using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] GameObject chunkPrefab;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] int chunkAmount;
    [SerializeField] Transform chunkParent;
    private GameObject chunk;
    private List<GameObject> chunkList;
    [SerializeField] private int chunkSpeed;
    private float timer;
    [SerializeField] private List<GameObject> preFabList;
    private int selector;


    void Start()
    {
        
        chunkList = new List<GameObject>();
        
        for (int i = 0; i < chunkAmount; i++)
        {
            chunk = Instantiate(chunkPrefab, transform.position + new Vector3(0, 0, i * 10), Quaternion.identity, chunkParent);
            chunkList.Add(chunk);
        }
        
        GameManager.Instance.AddScore();

    }

    void Update()
    {
        MoveChunks();
        DestroyStartAddEndChunk();
        
        // timer += Time.deltaTime;
        // while (timer > 0.5f)
        // {
        //     InstantiateObstacle();
        //     timer = 0;
        // }

        
    }

    private void AddEndChunk()
    {
        Vector3 AddPosition = chunkList[chunkList.Count - 1].transform.position + new Vector3(0, 0, 10);
        chunkList.Add(Instantiate(chunkPrefab, AddPosition, Quaternion.identity, chunkParent));
    }

    private void DestroyStartAddEndChunk()
    {
        if (chunkList[0].transform.position.z < -15)
        {
            Destroy(chunkList[0]);
            chunkList.RemoveAt(0);
            
            AddEndChunk();
        }
    }

    void MoveChunks()
    {
        foreach (GameObject chunk in chunkList)
        {
            if (chunk != null)
            {
                chunk.transform.position += Vector3.back * (chunkSpeed * Time.deltaTime);
            }
        }
    }

    void InstantiateObstacle()
    {
        selector = Random.Range(0, preFabList.Count);
        Instantiate(preFabList[selector], new Vector3(Random.Range(-3f, 3f), 6, 15), Random.rotation);
    }
    
}