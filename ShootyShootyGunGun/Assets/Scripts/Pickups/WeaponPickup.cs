using UnityEngine;

public class WeaponPickup : BasePickup
{
    [SerializeField] WeaponSO weaponSO;
    
    private void Start()
    {
       
        //Debug.Log(rotation);
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public override void HandlePickup(Collider other)
    {
        base.HandlePickup(other);
    }

    public override void HandleWeaponPickup(ActiveWeapon weapon)
    {
        base.HandleWeaponPickup(weapon);
        weapon.SwitchWeapon(weaponSO);
        weapon.ZeroOutAmmo();
        weapon.AdjustAmmo(weaponSO.MagazineSize);
        Destroy(this.gameObject);
    }
}
