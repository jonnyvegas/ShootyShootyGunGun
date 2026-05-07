using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    Animator animator;
    
    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;

    bool canShoot = true;
    float timeSinceLastShot = 0f;
    const string SHOOT_STRING = "Shoot";

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
        animator = GetComponent<Animator>();
    }

    private void PlayAnimAndFX()
    {
        animator.Play(SHOOT_STRING, 0, 0f);
    }

    private void HandleShoot()
    {
        if (!canShoot || !starterAssetsInputs.shoot)
        {
            return;
        }
        // start the timer check for cooldown.
        //timeSinceLastShot = 0f;
        canShoot = false;
        
        PlayAnimAndFX();
        //Debug.Log(shootDistance);
        //Debug.DrawRay(BarrelLoc.position, CameraLoc.forward * 10000f, Color.red, 100f);
        currentWeapon.Shoot(weaponSO);
        Debug.Log("Shooting. time since last: " + timeSinceLastShot);
        //starterAssetsInputs.ShootInput(false);
        //CheckHit(hit);

    }

    private void CheckCooldown()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= weaponSO.FireRate)
        {
            //Debug.Log("time since last shot: " + timeSinceLastShot);
            canShoot = true;
            timeSinceLastShot = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            CheckCooldown();
            //return;
        }
        if (starterAssetsInputs.shoot && canShoot)
        {
            HandleShoot();
        }
        else 
        {
            starterAssetsInputs.ShootInput(false);
        }
    }
}
