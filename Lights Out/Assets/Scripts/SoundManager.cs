using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void changeVolume() {
        AudioListener.volume = volumeSlider.value;
    }
}
