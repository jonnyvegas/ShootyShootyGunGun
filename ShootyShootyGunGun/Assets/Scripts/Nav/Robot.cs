using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform target;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
