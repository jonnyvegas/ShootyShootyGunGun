using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour, IEnemy
{
    NavMeshAgent agent;
    [SerializeField] Transform target;
    const string PLAYER_STRING = "Player";
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!target)
            return;
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
            return;
        agent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PLAYER_STRING))
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.SetHealth(0);
        }
    }

    virtual public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        //agent.SetDestination(target.position);
    }

    virtual public void Init(Transform newTarget)
    {
        SetTarget(newTarget);
    }
}
