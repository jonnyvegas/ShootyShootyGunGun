using UnityEngine;
using UnityEngine.Events;

public interface IHealth
{
    public UnityEvent<int> GetZeroHealthEvent() { return null; }
}

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] protected float health = 100f;
    float startingHealth = 100f;
    public float CurrentHealth => health;

    public UnityEvent<int> ZeroHealthEvent = new UnityEvent<int>();

    public void SetHealth(float health)
    {
        this.health = health;
        //Debug.Log("Current health: " + this.health);
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
