using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApolloMovement : MonoBehaviour
{
    public CharacterController2D controller;

    [SerializeField]public static float runSpeed = 100f;
    [SerializeField] private EnergyController energyController;
    public float currSpeed = runSpeed;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool boost = false;
    float runTime;

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
        if (Input.GetButtonDown("Fire2")) {
            boost = true;
        }
        if (Input.GetButton("Fire3")) {
            currSpeed = runSpeed * 1.5f;
            runTime += Time.deltaTime;
            Debug.Log(runTime);
            if(runTime >= 3) {
                energyController.UpdateEnergy(-10);
                runTime = 0f;
            }
        }
        if (Input.GetButtonUp("Fire3")) {
            currSpeed = runSpeed;
        }        

        if (Input.GetButtonDown("Crouch")) {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * currSpeed;

    }
    
    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, boost);
        jump = false;
        boost = false;
    }
}
