using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I am an idiot and used 3D vectors.... oops
public class CameraHandler : MonoBehaviour
{
    [SerializeField] private GameObject playableCharacter;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float cameraMoveSpeed;
    private Vector2 playerPos;
    private Vector2 cameraPos;
    float yPos = 0;
    float xPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playableCharacter.transform.position;

        if (playerPos.y > 4) {
            yPos = playerPos.y;
        } else if (playerPos.y > 2) {
            yPos = playerPos.y - (4 - playerPos.y); //Range of playerPos.y - 2 to playerPos.y over [2, 4]
        } else {
            yPos = 0;
        }


        if (playerPos.x >= -1) {
            xPos = playerPos.x;
        } else {
            xPos = -1;
        }

        mainCamera.transform.position = new Vector3(xPos, yPos, -10);
    }
}
