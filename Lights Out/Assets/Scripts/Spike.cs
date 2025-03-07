using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int spikeDamage;
    [SerializeField] private EnergyController energyController;

    void Awake() {
        energyController = FindObjectOfType<EnergyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            Debug.Log("Player Hit by Spike");
            Damage();
        }
    }

    void Damage() {
        Debug.Log("Updating energy");
        energyController.UpdateEnergy(spikeDamage);
    }
}
