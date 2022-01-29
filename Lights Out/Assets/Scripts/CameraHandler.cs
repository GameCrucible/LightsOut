using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    [SerializeField] private GameObject playableCharacter;
    private static Camera main;
    private float cameraX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraX = Camera.Transform.Position.X;
        Debug.Log(cameraX);
    }
}
