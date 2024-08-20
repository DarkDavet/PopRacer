using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float forwardSpeed = 5f;
    public float jumpForce = 5f;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 forwardMovement = transform.forward * forwardSpeed * Time.deltaTime;
        Vector3 horizontalMovement = transform.right * moveHorizontal * speed * Time.deltaTime;

        Vector3 movement = forwardMovement + horizontalMovement;
        controller.Move(movement);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
