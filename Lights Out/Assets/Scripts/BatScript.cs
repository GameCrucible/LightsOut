using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    [SerializeField] private int batDamage;
    [SerializeField] private EnergyController energyController;
    [SerializeField] private GameObject player;
    [SerializeField] private float triggerDistance;
    private bool awake = false;
    private string facing = "right";
    private float elapsedTime;
    private float precentageComplete = 0;
    private Vector2 batPosition;
    private Vector2 playerPosition;
    private Vector2 targetPosition;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private int health;


    void Awake() {
        energyController = FindObjectOfType<EnergyController>();
        player = GameObject.Find("Apollo_Concept_Art");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        batPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        //Finds players position each frame
        playerPosition = player.transform.position;
        if (!awake) {
           //Check if player is in radius
            if (PlayerDetected()) {
                targetPosition = new Vector2(batPosition.x, batPosition.y - 1.5f);
                awake = true;
            }
        } else {
            //If bat reaches destination, set new destination
            if (precentageComplete >= 1) {
                batPosition = targetPosition;
                targetPosition = playerPosition;
                elapsedTime = 0;
            }
            //Records how much time has passed for the lerp animation, percentage complete being the amount it's moved
            elapsedTime += Time.deltaTime;
            precentageComplete = elapsedTime / 1f;
            transform.position = Vector2.Lerp(batPosition, targetPosition, curve.Evaluate(precentageComplete));
        }
        if (playerPosition.x < batPosition.x && facing == "right") {
            facing = "left";
            transform.Rotate(0, 180, 0);
        } else if (playerPosition.x > batPosition.x && facing == "left") {
            facing = "right";
            transform.Rotate(0, -180, 0);
        }

    }

    private bool PlayerDetected() {
        playerPosition = player.transform.position;
            if (Mathf.Abs(Vector2.Distance(batPosition, playerPosition)) <= triggerDistance) {
                return true;
            } else {
                return false;
            }
    }
    
    public void TakeDamage (int damage) {
        health -= damage;

        if(health <= 0) {
            Die();
        }
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

    void Die() {
        Destroy(gameObject);
    }
}
