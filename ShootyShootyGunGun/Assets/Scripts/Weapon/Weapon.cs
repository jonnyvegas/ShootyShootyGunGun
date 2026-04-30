using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform BarrelLoc;
    [SerializeField] Transform CameraLoc;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Animator animator;
    [SerializeField] GameObject hitVFXPrefab;

    RaycastHit hit;
    StarterAssetsInputs starterAssetsInputs;
    float shootDistance = 50000f;
    Damage damage;
    const string SHOOT_STRING = "Shoot";
    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        damage = gameObject.AddComponent<Damage>();
    }

    private void CheckHit(RaycastHit hit)
    {
        Debug.Log("hit " + hit.collider.gameObject.name);
        if(hitVFXPrefab)
        {
            Instantiate(hitVFXPrefab, hit.point, Quaternion.identity);//hit.normal);
        }
        if (hit.collider.TryGetComponent(out Health health))
        {
            health.SetHealth(health.CurrentHealth - damage.Dmg);
        }
    }

    private void Shoot()
    {
        starterAssetsInputs.ShootInput(false);
        muzzleFlash.Play();
        animator.Play(SHOOT_STRING, 0, 0f);
        //Debug.Log(shootDistance);
        //Debug.DrawRay(BarrelLoc.position, CameraLoc.forward * 10000f, Color.red, 100f);
        if (!Physics.Raycast(BarrelLoc.position, CameraLoc.forward, out hit, shootDistance))
        {
            return;
        }
        CheckHit(hit);  
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
