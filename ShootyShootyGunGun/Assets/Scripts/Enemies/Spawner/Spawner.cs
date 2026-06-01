using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public interface ISpawner
{
    virtual public GameObject SpawnObject(GameObject obj) { return null; }
}

public class Spawner : MonoBehaviour, ISpawner
{
    //[SerializeField] protected GameObject objClassToSpawn;
    [SerializeField] string classToSpawn;
    [SerializeField] protected string[] objNames;
    [SerializeField] protected GameObject[] classesToSpawn;
    // Set this to 0 to spawn infinitely based on spawn interval.
    [SerializeField] int numToSpawn = 1;
    [SerializeField] float spawnInterval = 1f;
    [SerializeField] Transform spawnPoint;
    [SerializeField] protected GameObject player;
    protected Factory factory;
    Coroutine spawnCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public GameObject SpawnObject(string objName)
    {
        return factory.SpawnObj(objName, objNames, classesToSpawn);
    }

    public void BeginSpawn()
    {
        spawnCoroutine = StartCoroutine(HandleSpawnCoroutine());
    }

    public IEnumerator HandleSpawnCoroutine()
    {
        int numSpawned = 0;
        float spawnDeltaTime = 0f;
        SpawnObject(classToSpawn);
        numSpawned++;
        while ((numToSpawn == 0 || numSpawned < numToSpawn) && (!this.gameObject.IsDestroyed() || !player.IsDestroyed()))
        {
            spawnDeltaTime += Time.deltaTime;
            if (spawnDeltaTime >= spawnInterval)
            {
                SpawnObject(classToSpawn);
                spawnDeltaTime = 0f;
                numSpawned++;
            }
            yield return null;
        }
    }

    public void SetNewSpawnClassName(string newName)
    {
        classToSpawn = newName;
    }
}

