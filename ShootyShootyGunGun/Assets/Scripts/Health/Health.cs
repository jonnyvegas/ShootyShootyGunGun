using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float health = 100f;
    float startingHealth = 100f;
    public float CurrentHealth => health;

    public void SetHealth(float health)
    {
        this.health = health;
        Debug.Log("Current health: " + this.health);
        if(health < 0 )
        {
            OnZeroHealth();
        }
    }

    virtual public void OnZeroHealth()
    {

    }
}
