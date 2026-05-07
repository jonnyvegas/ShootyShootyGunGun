using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] Transform BarrelLoc;
    [SerializeField] Transform CameraLoc;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Animator animator;
    [SerializeField] GameObject hitVFXPrefab;

    RaycastHit hit;
    StarterAssetsInputs starterAssetsInputs;
    float shootDistance = 50000f;
    //Damage damage;
    const string SHOOT_STRING = "Shoot";
    float aggregTime = 0f;
    bool canShoot = true;
    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        //damage = gameObject.AddComponent<Damage>();
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
            health.SetHealth(health.CurrentHealth - weaponSO.Damage);
        }
    }

    private void PlayAnimAndFX()
    {
        muzzleFlash.Play();
        animator.Play(SHOOT_STRING, 0, 0f);
    }

    private void Shoot()
    {
        if (!canShoot)
        {
            return;
        }
        // start the timer check for cooldown.
        canShoot = false;
        starterAssetsInputs.ShootInput(false);
        PlayAnimAndFX();
        //Debug.Log(shootDistance);
        //Debug.DrawRay(BarrelLoc.position, CameraLoc.forward * 10000f, Color.red, 100f);
        if (!Physics.Raycast(BarrelLoc.position, CameraLoc.forward, out hit, shootDistance))
        {
            return;
        }
        CheckHit(hit);
        
    }

    private void CheckCooldown()
    {
        aggregTime += Time.deltaTime;
        if (aggregTime >= weaponSO.FireRate)
        {
            canShoot = true;
            aggregTime = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            CheckCooldown();
            return;
        }
        if (starterAssetsInputs.shoot)
        {
            Shoot();
        }
        
    }
}
