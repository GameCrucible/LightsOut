using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    //[SerializeField] private Camera playerCam; 

    Vector2 lookDirection;
    float lookAngle;

    // Update is called once per frame
    void Update()
    {
        /*
        lookDirection = playerCam.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        Debug.Log(lookAngle);
        
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        */
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        firePoint.eulerAngles = new Vector3(0, 0, angle);

        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    //Shooting logic
    void Shoot() {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public static Vector3 GetMouseWorldPosition() {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
