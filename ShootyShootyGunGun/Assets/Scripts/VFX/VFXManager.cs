using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] GameObject DeathVFXPrefab;
    [SerializeField] Health healthRef;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthRef.ZeroHealthEvent += InstantiateDeathPrefab;
    }

    void InstantiateDeathPrefab()
    {
        Instantiate(DeathVFXPrefab, gameObject.transform.position, Quaternion.identity);
        //Debug.Log(this.gameObject.transform.position.ToString());
    }
}
