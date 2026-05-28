using UnityEngine;

public class EnemyFactory : Factory
{
    //[SerializeField] Transform target;
    public override GameObject SpawnObj(string objToSpawn, string[] objNames, GameObject[] gameObjs)
    {
        return base.SpawnObj(objToSpawn, objNames, gameObjs);
    }
}
