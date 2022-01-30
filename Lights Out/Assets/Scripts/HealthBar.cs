using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject HealthBarsSprite;
    [SerializeField] private GameObject EnergyController;
    
    // Start is called before the first frame update
    void Awake()
    {
        HealthBarsSprite = GameObject.Find("HealthBars");
        EnergyController = GameObject.Find("EnergyController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
