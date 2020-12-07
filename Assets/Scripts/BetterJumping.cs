using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT MANIPULATES THE JUMP DISTANCE OF THE PLAYER BASED ON HOW LONG THEY PRESSED THE JUMP BUTTON

public class BetterJumping : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private bool jumpPressed;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    //We handle player input in Update
    void Update()
    {
        jumpPressed = Input.GetButton("Button A");
    }

    //And we handle everything physics related in this FixedUpdate
    private void FixedUpdate()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !jumpPressed)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
