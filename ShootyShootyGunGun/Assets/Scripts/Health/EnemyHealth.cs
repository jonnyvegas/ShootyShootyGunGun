using UnityEngine;

public class EnemyHealth : Health
{
    GameManager gameManager;
    
    private void Awake()
    {
        //health = 50f;
    }

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        gameManager.AdjustEnemiesLeft(1);
    }

    public override void OnZeroHealth()
    {
        base.OnZeroHealth();
        gameManager.AdjustEnemiesLeft(-1);
        SelfDestruct();
    }

    public void SelfDestruct()
    {
        //OnZeroHealth();
        Destroy(this.gameObject);
    }
}
