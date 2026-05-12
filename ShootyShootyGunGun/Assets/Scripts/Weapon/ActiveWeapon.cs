using StarterAssets;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    Animator animator;
    
    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;
    FirstPersonController firstPersonController;

    bool canShoot = true;
    float timeSinceLastShot = 0f;
    const string SHOOT_STRING = "Shoot";
    const string ZOOM_STRING = "Zoom";

    PlayerInput playerInput;
    //InputAction shootAction;
    InputAction zoomAction;
    float zoomTime = 5f;
    float zoomDelta = 0f;
    float originalFOV = 0f;
    float originalRotSpeed = 0f;
    Coroutine zoomCoroutineRef;

    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] GameObject zoomVignette;

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        PlayerInput playerInput = GetComponentInParent<PlayerInput>();
        //shootAction = playerInput.actions[SHOOT_STRING];
        zoomAction = playerInput.actions[ZOOM_STRING];
        zoomAction.started += StartZoomIn;
        zoomAction.canceled += CancelZoomIn;
        firstPersonController = GetComponentInParent<FirstPersonController>();
        originalRotSpeed = firstPersonController.RotationSpeed;
        //zoomAction.bin
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
        animator = GetComponent<Animator>();
        originalFOV = cam.m_Lens.FieldOfView;
    }

    private void PlayAnim()
    {
        animator.Play(SHOOT_STRING, 0, 0f);
    }

    private void HandleShoot()
    {
        if (!canShoot || !starterAssetsInputs.shoot)
        {
            return;
        }
        // start the timer check for cooldown.
        //timeSinceLastShot = 0f;
        canShoot = false;
        PlayAnim();
        currentWeapon.Shoot(weaponSO);
    }

    private void CheckCooldown()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= weaponSO.FireRate)
        {
            //Debug.Log("time since last shot: " + timeSinceLastShot);
            canShoot = true;
            timeSinceLastShot = 0f;
        }
        else
        {
            if (!weaponSO.IsAutomatic)// || !shootAction.IsPressed())
            { 
                starterAssetsInputs.ShootInput(false); 
            }
        }
    }

    private void UpdateShoot()
    {
        if (!canShoot)
        {
            CheckCooldown();
            return;
        }
        if (starterAssetsInputs.shoot && canShoot)
        {
            HandleShoot();
        }
    }

    private IEnumerator ZoomCoroutine(bool zoomIn)
    {
       // Debug.Log("StartCoroutine");
        zoomDelta = 0f;
        //float zoomAlpha = zoomIn ? (zoomDelta / zoomTime) : (1 - (zoomDelta / zoomTime));
        //Debug.Log("zoom time " + zoomTime);   
        //Debug.Log(zoomIn);
        while(zoomDelta < zoomTime)
        {

            cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, zoomIn ? weaponSO.ZoomFOV : originalFOV, zoomDelta / zoomTime);

            //cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, originalFOV, zoomDelta / zoomTime);


            zoomDelta += Time.deltaTime;
            //Debug.Log("zoom delta: " + zoomDelta);
            yield return null;
        }
    }


    private void StartZoomIn(InputAction.CallbackContext context)
    {
        if (!weaponSO.IsZoomable) 
        { 
            return; 
        }
        StopAllCoroutines();
        zoomCoroutineRef = StartCoroutine(ZoomCoroutine(true));
        zoomVignette.SetActive(true);
        firstPersonController.ChangeRotationSpeed(weaponSO.ZoomRotationSpeed);
       // Debug.Log("Button pressed");

    }

    private void CancelZoomIn(InputAction.CallbackContext context)
    {
        if (!weaponSO.IsZoomable)
        {
            return;
        }

        StopAllCoroutines(); 
        zoomCoroutineRef = StartCoroutine(ZoomCoroutine(false));
        zoomVignette.SetActive(false);
        firstPersonController.ChangeRotationSpeed(originalRotSpeed);
       // Debug.Log("Button released");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateShoot();
    }

    public void SwitchWeapon(WeaponSO newWeaponSO)
    {
        if(currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }
        Weapon newWeapon = Instantiate(newWeaponSO.WeaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = newWeaponSO;
    }
}
