using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    [SerializeField] float damage = 5f;
    [SerializeField] float speed = 10f;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, (transform.position + transform.forward * speed * Time.deltaTime), 1.0f);
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        IHealth health = other.GetComponentInParent<IHealth>();
        if(health as UnityEngine.Object)
        {
            health.SetHealth(health.CurrentHealth - this.damage);
        }
        Destroy(this.gameObject);
    }
}
