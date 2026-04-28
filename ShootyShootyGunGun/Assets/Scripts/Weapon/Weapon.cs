using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Transform CameraLoc;
    [SerializeField] ParticleSystem muzzleFlash;
    
    RaycastHit hit;
    StarterAssetsInputs starterAssetsInputs;
    float shootDistance = 10000f;
    Damage damage;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        damage = gameObject.AddComponent<Damage>();
    }

    private void CheckHit(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent(out Health health))
        {
            health.SetHealth(health.CurrentHealth - damage.Dmg);
        }
    }

    private void Shoot()
    {
        //Debug.DrawRay(CameraLoc.position, CameraLoc.forward * shootDistance, Color.red, 100f);
        if (Physics.Raycast(CameraLoc.position, CameraLoc.forward, out hit, shootDistance))
        {
            CheckHit(hit);

        }
        starterAssetsInputs.ShootInput(false);
        muzzleFlash.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (starterAssetsInputs.shoot)
        {
            Shoot();
        }
    }
}
