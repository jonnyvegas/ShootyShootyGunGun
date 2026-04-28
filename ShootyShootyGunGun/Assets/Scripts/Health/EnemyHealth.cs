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
        Destroy(this.gameObject);
    }
}
