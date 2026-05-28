using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    public virtual GameObject SpawnObj(string objToSpawn, string[] objNames, GameObject[] gameObjs)
    {
        for (int i = 0; i < objNames.Length; i++)
        {
            if (objToSpawn == objNames[i])
            {
                return Instantiate(gameObjs[i], this.gameObject.transform.position, Quaternion.identity);
            }
        }
        return null;
    } 
}
