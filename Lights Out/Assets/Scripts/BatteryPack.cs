using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPack : MonoBehaviour
{
    [SerializeField] private int packHealth;
    [SerializeField] private EnergyController energyController;

    void Awake() {
        energyController = FindObjectOfType<EnergyController>();
    }

     private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            if(energyController.currEnergy != 100){
                Debug.Log("Player Healed");
                Heal();
            }
        }
    }

    void Heal() {
        energyController.UpdateEnergy(packHealth);
        Destroy(gameObject);
    }
}
