using UnityEngine;

public class EnemyFactory : Factory
{
    public override GameObject SpawnObj(string objToSpawn, string[] objNames, GameObject[] gameObjs)
    {
        return base.SpawnObj(objToSpawn, objNames, gameObjs);
    }
}
