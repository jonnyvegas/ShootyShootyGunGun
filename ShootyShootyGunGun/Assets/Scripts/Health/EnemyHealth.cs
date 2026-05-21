using UnityEngine;

public class EnemyHealth : Health
{
    private void Awake()
    {
        //health = 50f;
    }
    public override void OnZeroHealth()
    {
        base.OnZeroHealth();
        SelfDestruct();
    }

    public void SelfDestruct()
    {
        //OnZeroHealth();
        Destroy(this.gameObject);
    }
}
