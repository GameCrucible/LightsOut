using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        Debug.Log(hitInfo);
        
        BatScript enemy = hitInfo.GetComponent<BatScript>();
        if (enemy != null) {
            enemy.TakeDamage(50);
        }
        
        Destroy(gameObject);
    }
    void Update() {
        elapsedTime += Time.deltaTime;
        if(rb.velocity == new Vector2(0f, 0f)) {
            Destroy(gameObject);
        }

        if(elapsedTime >= 0.75f) {
            Destroy(gameObject);
        }
    }
}
