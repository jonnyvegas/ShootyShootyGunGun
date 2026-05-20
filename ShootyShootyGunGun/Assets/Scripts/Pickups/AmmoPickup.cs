using UnityEngine;

public class AmmoPickup : BasePickup
{
    [SerializeField] int ammoAmt = 100;
    const string PLAYER_TAG = "Player";
    public override void HandlePickup(Collider other)
    {
        base.HandlePickup(other);
        //Destroy(this.gameObject);
    }

    public override void HandleWeaponPickup(ActiveWeapon weapon)
    {
        if(weapon.CurrentAmmo == weapon.CurrentWeaponSO.MagazineSize)
        {
            return;
        }
        weapon.AdjustAmmo(ammoAmt);
        DestroyPickup();
    }
}
