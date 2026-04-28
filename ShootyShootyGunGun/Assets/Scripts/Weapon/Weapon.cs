using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform CameraLoc;
    RaycastHit hit;
    StarterAssetsInputs starterAssetsInputs;
    float shootDistance = 10000f;
    Damage damage;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        damage = gameObject.AddComponent<Damage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (starterAssetsInputs.shoot)
        {
            //Debug.DrawRay(CameraLoc.position, CameraLoc.forward * shootDistance, Color.red, 100f);
            if (Physics.Raycast(CameraLoc.position, CameraLoc.forward, out hit, shootDistance))
            {
                if(hit.collider.TryGetComponent(out Health health))
                {
                    health.SetHealth(health.CurrentHealth - damage.Dmg);
                }
            }
            starterAssetsInputs.ShootInput(false);
        }
    }
}
