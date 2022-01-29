using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    [SerializeField] private int batDamage;
    [SerializeField] private EnergyController energyController;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject localBat;
    [SerializeField] private float triggerDistance;
    private bool seeking = false;
    private Vector2 batPosition;
    private Vector2 playerPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (seeking) {
            //Have bat head towards player

        } else {
            //Check if player is in radius
            batPosition = localBat.transform.position;
            playerPosition = player.transform.position;
            if (Mathf.Abs(Vector2.Distance(batPosition, playerPosition)) <= triggerDistance) {
                TriggerBat();
            }
        }
    }

    private void TriggerBat() {
        //Move bat down and hover for a second, then begin seeking
        Debug.Log("Bat Triggered");
        seeking = true;
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            Debug.Log("Player Hit");
            Damage();
        }
    }

    void Damage() {
        energyController.UpdateEnergy(batDamage);
    }
}
