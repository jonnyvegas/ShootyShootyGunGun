using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform CameraLoc;
    RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(CameraLoc.position, CameraLoc.forward * 1000f, Color.red);
        if (Physics.Raycast(CameraLoc.position, CameraLoc.forward, out hit, 1000f))
        {
            
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
