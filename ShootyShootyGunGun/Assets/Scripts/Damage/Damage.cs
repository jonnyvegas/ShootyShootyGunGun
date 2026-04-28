using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float dmg = 35f;
    public float Dmg => dmg;

    public void SetDamage(float damage)
    {
        this.dmg = damage;
    }
}
