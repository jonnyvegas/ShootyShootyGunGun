using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform projectileSpawnLoc;
    [SerializeField] GameObject projectileClass;
    bool shouldFire = true;
    Vector3 position;
    Quaternion rotation;
    Coroutine fireProjectileCoroutine;
    float fireRate = 1.0f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileDamage = 5f;
    PlayerHealth ph;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BeginFiring();
    }

    void BeginFiring()
    {
        fireProjectileCoroutine = StartCoroutine(FireProjectileCoroutine());
        ph = FindAnyObjectByType<PlayerHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!playerTransform || !turretHead)
            return;

        // these are equivalent.
        //turretHead.LookAt(playerTransform);
        position = playerTransform.position - turretHead.position;
        rotation = Quaternion.LookRotation(position);
        turretHead.rotation = rotation;
    }

    IEnumerator FireProjectileCoroutine()
    {
        // wait one cycle before firing.
        yield return new WaitForSeconds(fireRate);
        shouldFire = ph;
        while (shouldFire)
        {
            FireProjectile();
            shouldFire = ph;
            yield return new WaitForSeconds(fireRate);
        }
    }

    void FireProjectile()
    {
        //Debug.Log("Fire at player");
        TurretProjectile tp = Instantiate(projectileClass, projectileSpawnLoc.position, turretHead.transform.rotation).GetComponent<TurretProjectile>();
        tp.Init(projectileDamage, projectileSpeed, playerTransform);
    }
}
