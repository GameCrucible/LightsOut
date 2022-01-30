using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    public int currEnergy;
    [SerializeField] private CharacterController2D characterController;
    [SerializeField] FlashImage flashImage = null;
    private bool debounce;
    private float timeSinceHit;

    void Update() {
        timeSinceHit += Time.deltaTime;
    }
    
    public void UpdateEnergy(int amount) {
        if (timeSinceHit > .5) {
            timeSinceHit = 0;
            if (amount < 0) {
                flashImage.StartFlash(.05f, .35f);
            }
            currEnergy = currEnergy + amount;
            if(currEnergy < 1) {
                characterController.death();
            } else if(currEnergy > 100) {
                currEnergy = 100;
            }
        }
    }
}
