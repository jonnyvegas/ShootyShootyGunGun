using UnityEngine;
using UnityEngine.Events;

public interface IHealth
{
    public UnityEvent<int> GetZeroHealthEvent() { return null; }
    public void TakeDamage(float damage);
    public void SetHealth(float health);
    public float CurrentHealth { get; }
}

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] float startingHealth = 100f;
    protected float health = 100f;
    
    public float CurrentHealth => health;

    public UnityEvent<int> ZeroHealthEvent = new UnityEvent<int>();

    public void TakeDamage(float damage)
    {
        SetHealth(health - damage);
    }
    public void SetHealth(float health)
    {
        this.health = health;
        if(health <= 0 )
        {
            OnZeroHealth();
        }
    }

    virtual public void OnZeroHealth()
    {
        // passing starting health as a test to make sure
        // this is being done correctly.
        ZeroHealthEvent?.Invoke((int)startingHealth);
    }

    public void ResetHealth()
    {
        health = startingHealth;
    }

    public UnityEvent<int> GetZeroHealthEvent()
    {
        return ZeroHealthEvent;
    }
}
