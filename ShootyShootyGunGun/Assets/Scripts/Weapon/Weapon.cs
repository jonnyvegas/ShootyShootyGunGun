using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform CameraLoc;
    RaycastHit hit;
    StarterAssetsInputs starterAssetsInputs;
    float shootDistance = 10000f;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (starterAssetsInputs.shoot)
        {
            //Debug.DrawRay(CameraLoc.position, CameraLoc.forward * shootDistance, Color.red, 100f);
            if (Physics.Raycast(CameraLoc.position, CameraLoc.forward, out hit, shootDistance))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
            starterAssetsInputs.ShootInput(false);
        }
    }
}
