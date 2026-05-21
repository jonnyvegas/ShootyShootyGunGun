using Mono.Cecil.Cil;
using Unity.Hierarchy;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;
    const string PLAYER_TAG = "Player";
    private void Start()
    {
        Explode();
    }

    // Only for debugging.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        
        foreach (Collider theCollider in colliders)
        {
            if (!theCollider.gameObject.CompareTag(PLAYER_TAG))
            {
                continue;
            }
            // We can stop once we get the Player for now. We may revisit this later. 
            if (theCollider.TryGetComponent(out IHealth health))
            {
                //Debug.Log(theCollider.gameObject);
                health.TakeDamage(35);
                break;
            }
        }
    }
}
