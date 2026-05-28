using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] Transform target;
    private void Awake()
    {
        factory = this.AddComponent<EnemyFactory>();
    }
    private void Start()
    {
        BeginSpawn();
    }
    public override GameObject SpawnObject(string objName)
    {
        Robot robot = base.SpawnObject(objName).GetComponent<Robot>();
        robot.Init(player.transform);
        return robot.gameObject;
    }
}

