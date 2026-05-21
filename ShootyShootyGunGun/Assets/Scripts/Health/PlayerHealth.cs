using UnityEngine;

public class PlayerHealth : Health
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnZeroHealth()
    {
        base.OnZeroHealth();
        Destroy(this.gameObject);
    }
}
