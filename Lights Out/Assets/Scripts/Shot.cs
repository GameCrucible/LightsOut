using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    Vector2 lookDirection;
    float lookAngle;

    // Update is called once per frame
    void Update()
    {
        
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        Debug.Log(lookAngle);
        
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        
        /*
        if(Input.GetButtonDown("Horizontal")) {
            if(Input.GetButtonDown("Up"))) {
                firePoint.transform.SetPositionAndRotation();
            }
            if(Input.GetButtonDown("Down")) {
                firePoint.transform.SetPositionAndRotation();
            }
        } else() {
            */
            /*
            if(Input.GetAxisRaw("Vertical") > 0) {
                firePoint.transform.SetPositionAndRotation(new Vector3(0f, 5.5f, 0f), new Quaternion(0f, 0f, 90f, 0f));
            }
            if(Input.GetAxisRaw("Vertical") < 0) {
                firePoint.transform.SetPositionAndRotation(new Vector3(0f, -6.6f, 0f), new Quaternion(0f, 0f, -90f, 0f));
            }
            if(Input.GetAxisRaw("Vertical") == 0) {
                firePoint.transform.SetPositionAndRotation(new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            }
            
        }
        */
        
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    //Shooting logic
    void Shoot() {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
