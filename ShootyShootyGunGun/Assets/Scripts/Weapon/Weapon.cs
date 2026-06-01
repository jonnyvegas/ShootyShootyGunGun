//using StarterAssets;
using Unity.Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    [SerializeField] Transform BarrelLoc;
   // [SerializeField] Transform CameraLoc;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayers;
    [SerializeField] CinemachineImpulseSource impulseSource;

    RaycastHit hit;
    
    float shootDistance = 50000f;
    //Damage damage;
    

    private void CheckHit(RaycastHit hit, WeaponSO weaponSO)
    {
        Debug.Log("hit " + hit.collider.gameObject.name);
        if(weaponSO.HitVFXPrefab)
        {
            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);//hit.normal);
        }
        IHealth health = hit.collider.GetComponentInParent<IHealth>();
        // check if interface is not null as if(health) and if(health != null) do not work.
        if(health as UnityEngine.Object)
        {
            health.TakeDamage(weaponSO.Damage);
        }
    }



    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlash.Play();
        impulseSource.GenerateImpulse();
        if (!Physics.Raycast(BarrelLoc.position, Camera.main.transform.forward, out hit, shootDistance, interactionLayers, QueryTriggerInteraction.Ignore))
        {
            return;
        }
        CheckHit(hit, weaponSO);

    }
}
