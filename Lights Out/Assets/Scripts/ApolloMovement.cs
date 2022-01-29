using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApolloMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float maxSpeed;
    public float currSpeed;
    public float jumpForce;

    public int light;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

    }

    void Jump(){

    }

    void Move(){
        
    }

    void checkLight(){

    }

    void CheckIfGrounded(){

    }
}
