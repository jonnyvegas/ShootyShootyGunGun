using StarterAssets;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBarImgs;
    [SerializeField] GameObject gameOverContainer;
    int gameOverVirtualCameraPriority = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AdjustShieldUI();
        ShowOrHideGameOverContainer(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerDeath()
    {
        weaponCamera.parent = null;
        deathVirtualCamera.Priority = gameOverVirtualCameraPriority;
        ShowOrHideGameOverContainer(true);
        StarterAssetsInputs starterAssetsInputs = FindAnyObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);
        Destroy(this.gameObject);
    }

    public override void OnZeroHealth()
    {
        base.OnZeroHealth();
        PlayerDeath();
    }

    public override void TakeDamage(float damage)
    {
        Debug.Log("taking damage " + damage);
        base.TakeDamage(damage);
        Debug.Log("new health: " + this.health);
        AdjustShieldUI();
    }

    void AdjustShieldUI()
    {
        for(int i = 0; i < shieldBarImgs.Length; i++)
        {
           Debug.Log((i + 1) * 10);
           shieldBarImgs[i].gameObject.SetActive(health >= ((i + 1) * 10)); 
        }
    }

    void ShowOrHideGameOverContainer(bool show)
    {
        gameOverContainer.SetActive(show);
    }
}
