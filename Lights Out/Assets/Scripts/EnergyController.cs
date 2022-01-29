using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    public int currEnergy;
    [SerializeField] private CharacterController2D characterController;
    
    public void UpdateEnergy(int amount) {
        currEnergy = currEnergy + amount;
        if(currEnergy < 1) {
            characterController.death();
        } else if(currEnergy > 100) {
            currEnergy = 100;
        }
    }
}
