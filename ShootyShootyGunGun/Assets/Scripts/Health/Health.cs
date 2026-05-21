using UnityEngine;
using UnityEngine.Events;

public interface IHealth
{
    virtual public UnityEvent<int> GetZeroHealthEvent() { return null; }
    virtual public UnityEvent<float> GetOnHealthChanged() { return null; }
    virtual public void TakeDamage(float damage) { }
    virtual public void SetHealth(float health) { }
    public float CurrentHealth { get; }
}

public class Health : MonoBehaviour, IHealth
{
    [Range(1, 100)]
    [SerializeField] float startingHealth = 100f;
    protected float health = 100f;
    
    public float CurrentHealth => health;

    public UnityEvent<int> ZeroHealthEvent = new UnityEvent<int>();
    public UnityEvent<float> OnHealthChangedEvent = new UnityEvent<float>();

    virtual public void TakeDamage(float damage)
    {
        SetHealth(health - damage);
    }
    public void SetHealth(float health)
    {
        float prevHealth = this.health;
        this.health = health;
        if(health <= 0 )
        {
            OnZeroHealth();
        }
        if(prevHealth != this.health)
        {
            OnHealthChangedEvent?.Invoke(this.health);
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

    public UnityEvent<float> GetOnHealthChanged()
    {
        return OnHealthChangedEvent;
    }
}
