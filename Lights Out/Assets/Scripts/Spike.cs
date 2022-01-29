using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int spikeDamage;
    [SerializeField] private EnergyController energyController;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            Debug.Log("Player Hit");
            Damage();
        }
    }

    void Damage() {
        energyController.UpdateEnergy(spikeDamage);
    }
}
