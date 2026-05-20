using UnityEngine;

public class BasePickup : MonoBehaviour
{
    protected const string PLAYER_STRING = "Player";
    float rotationSpeed = 100f;
    float amtToRotate = 1f;
    [SerializeField] bool shouldRotate = true;
    [SerializeField] bool destroyAfterPickup = true;
    Vector3 rotation = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotation = Vector3.zero;
        rotation.y = amtToRotate;
    }

    // Update is called once per frame
    void Update()
    {
        if(!shouldRotate)
        { 
            return; 
        }
        this.gameObject.transform.Rotate(rotation * Time.deltaTime * rotationSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        HandlePickup(other);
    }

    public virtual void HandlePickup(Collider other)
    {
        ActiveWeapon weapon = other.GetComponentInChildren<ActiveWeapon>();
        if(weapon)
        {
            HandleWeaponPickup(weapon);
        }
        //Destroy(this.gameObject);
    }

    public virtual void HandleWeaponPickup(ActiveWeapon weapon)
    {

    }

    public void DestroyPickup()
    {
        if(!destroyAfterPickup)
        {
            return;
        }
        Destroy(this.gameObject);
    }
}
