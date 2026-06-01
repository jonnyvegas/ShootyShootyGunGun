using UnityEngine;

public class DeathVFXManager : MonoBehaviour
{
    [SerializeField] GameObject DeathVFXPrefab;
    GameObject healthGO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        healthGO = GetComponent<Health>().gameObject;
    }
    
    void Start()
    {
        if(healthGO.TryGetComponent(out IHealth health))
        {
            health.GetZeroHealthEvent().AddListener(InstantiateDeathPrefab);
        }
        
    }

    void InstantiateDeathPrefab(int num)
    {
        Debug.Log("We passed " + num);
        Instantiate(DeathVFXPrefab, gameObject.transform.position, Quaternion.identity);
        //Debug.Log(this.gameObject.transform.position.ToString());
    }
}
