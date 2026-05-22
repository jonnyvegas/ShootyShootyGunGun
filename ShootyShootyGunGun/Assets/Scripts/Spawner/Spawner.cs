using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public interface ISpawner
{
    virtual public GameObject SpawnObject(GameObject obj) { return null; }
}

public class Spawner : MonoBehaviour, ISpawner
{
    [SerializeField] protected GameObject objClassToSpawn;
    // Set this to 0 to spawn infinitely based on spawn interval.
    [SerializeField] int numToSpawn = 1;
    [SerializeField] float spawnInterval = 1f;
    [SerializeField] Transform spawnPoint;
    [SerializeField] protected GameObject player;
    Coroutine spawnCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public GameObject SpawnObject(GameObject obj)
    {
        return Instantiate(obj, spawnPoint.position, Quaternion.identity);
    }

    public void BeginSpawn()
    {
        spawnCoroutine = StartCoroutine(HandleSpawnCoroutine());
    }

    public IEnumerator HandleSpawnCoroutine()
    {
        int numSpawned = 0;
        float spawnDeltaTime = 0f;
        SpawnObject(objClassToSpawn);
        numSpawned++;
        while ((numToSpawn == 0 || numSpawned < numToSpawn) && (!this.gameObject.IsDestroyed() || !player.IsDestroyed()))
        {
            spawnDeltaTime += Time.deltaTime;
            if (spawnDeltaTime >= spawnInterval)
            {
                SpawnObject(objClassToSpawn);
                spawnDeltaTime = 0f;
                numSpawned++;
            }
            yield return null;
        }
    }
}

