using UnityEngine;

public class EnemySpawner : Spawner
{
    private void Start()
    {
        BeginSpawn();
    }
    public override GameObject SpawnObject(GameObject obj)
    {
        Robot robot = base.SpawnObject(obj).GetComponent<Robot>();
        robot.SetTarget(player.transform);
        return robot.gameObject;
    }
}

