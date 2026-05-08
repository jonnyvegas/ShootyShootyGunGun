using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    float rotationSpeed = 100f;
    float amtToRotate = 1f;
    Vector3 rotation = Vector3.zero;

    const string PLAYER_STRING = "Player";
    private void Start()
    {
        rotation = Vector3.zero;
        rotation.y = amtToRotate;
        Debug.Log(rotation);
    }
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(rotation * Time.deltaTime * rotationSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("trigger enter");
        if (other.CompareTag(PLAYER_STRING))
        {
            ActiveWeapon weapon = other.GetComponentInChildren<ActiveWeapon>();
            if (weapon)
            {
                weapon.SwitchWeapon(weaponSO);
                Destroy(this.gameObject);
            }
        }
    }
}
