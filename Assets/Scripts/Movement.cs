using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(1, 100)]
    public float jumpVelocity;

    [Range(1, 20)]
    public float movementSpeed;

    [Range(1, 20)]
    public float movementSpeedLimit = 8;

    public float GroundDistance = 0.2f;
    public LayerMask Ground;

    private Rigidbody rb;
    private AudioSource playerAudio;
    private bool isGrounded = true;
    private Transform groundChecker;
    private Vector3 movementInput;

    public Animator animator;
    public Animator animator2;
    bool isMoving = false;
    bool facingRight = true;

    public AudioClip saltoSFX;

    float movementSpeedSaved;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        //The first child should always be an empty object. We'll use this to check if the player is touching the ground.
        groundChecker = transform.GetChild(0);
        movementSpeedSaved = movementSpeed;
    }

    private void Update()
    {
        if (!PlayerCombat.gameover && !GameManager.instance.win)
        {
            //Checks if the character is grounded.
            isGrounded = Physics.CheckSphere(groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
            movementInput = Vector3.zero;
            //Cambiar controles segun la perspectiva de la camara
            if (Camera_Transition.ortho)
            {
                movementInput.z = Input.GetAxisRaw("Horizontal");
                if (movementInput.z > 0)
                {
                    facingRight = true;
                }
                else
                {
                    facingRight = false;
                }
            }
            else
            {
                if (Camera_Transition.inverse)
                {
                    movementInput.x = Input.GetAxisRaw("Horizontal") * -1;
                    movementInput.z = Input.GetAxisRaw("Vertical") * -1;
                    if (movementInput.x > 0)
                    {
                        facingRight = false;
                    }
                    else
                    {
                        facingRight = true;
                    }
                }
                else
                {
                    movementInput.x = Input.GetAxisRaw("Horizontal");
                    movementInput.z = Input.GetAxisRaw("Vertical");
                    if (movementInput.x > 0)
                    {
                        facingRight = true;
                    }
                    else
                    {
                        facingRight = false;
                    }
                }

            }


            if (movementInput != Vector3.zero)
            {
                transform.forward = movementInput;
                animator.SetBool("IsWalking", true);
                animator2.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
                animator2.SetBool("IsWalking", false);
            }
            if (Input.GetButtonDown("Button A") && isGrounded)
            {
                Jump();
            }
            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Button B")) && (movementInput.x != 0.0f || movementInput.z != 0.0f))
            {
                if (movementSpeed < movementSpeedLimit)
                {
                    movementSpeed += 0.1f;
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetButtonUp("Button B"))
            {
                movementSpeed = movementSpeedSaved;
            }
            if (true)
            {
                animator.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                animator2.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        
    }

    void FixedUpdate()
    {
        //ClampMagnitude clamps the magnitude of the vector so that diagonal movement won't be faster than horizontal or vertical movement.
        rb.MovePosition(rb.position + Vector3.ClampMagnitude(movementInput * movementSpeed, movementSpeedLimit) * Time.fixedDeltaTime);
    }

    void Jump()
    {
        playerAudio.clip = saltoSFX;
        playerAudio.Play();
        rb.velocity = Vector3.up * jumpVelocity;
    }
}
