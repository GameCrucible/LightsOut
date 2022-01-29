using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    //This wasn't working, it couldn't recognize the GameObject
    //[SerializeField] private GameObject playableCharacter;
    [SerializeField] private Camera mainCamera;
    private float cameraX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraX = mainCamera.transform.position.x;
        Debug.Log(cameraX);
    }
}
