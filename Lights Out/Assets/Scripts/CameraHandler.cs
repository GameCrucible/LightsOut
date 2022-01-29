using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private GameObject playableCharacter;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float cameraMoveSpeed;
    /*private float cameraX = 0f;
    private float cameraY = 0f;*/
    private Vector3 playerPos;
    private Vector3 cameraPos;
    /*private Vector3 camDestination;
    private float z = -10;
    private Vector3 destination = new Vector3(0, 0, -10);*/

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPos = mainCamera.transform.position;
        playerPos = playableCharacter.transform.position;
        mainCamera.transform.position = new Vector3(playerPos.x, 0, -10);



        /* ---------Fix later if have time, for tweening camera and more fluid camera movement
        cameraX = mainCamera.transform.position.x; //Get camera position each frame
        cameraY = mainCamera.transform.position.y;
        cameraPos = mainCamera.transform.position;
        playerPos = playableCharacter.transform.position;
        

        //Logic that handles detecting new camera position
        if (Mathf.Abs(playerPos.x - cameraX) >= 1.5f) 
        {
            Debug.Log(Mathf.Abs(playerPos.x - cameraX));
            destination = new Vector3.Lerp(cameraPos, 0, -10); //Create a Tween if have the time
            //Add nested if to handle y changes, else just move to new X
        }
        camDestination = new Vector3(playerPos.x, 0, -10);


        mainCamera.transform.position = Vector3.Lerp(cameraPos, camDestination, cameraMoveSpeed);




        /*destination = new Vector3(playerPos.x, 0, -10); //Create a Tween if have the time
        mainCamera.transform.position = destination;*/
    }
}
