using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f;
    // public float rotationSpeed = 1f;

    private void FixedUpdate()
    {
        MoveCharacter();
    }
    

    private void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal == 0 && vertical == 0) return;
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        rb.linearVelocity = moveDirection * moveSpeed;
        transform.rotation = Quaternion.LookRotation(moveDirection);
    }
}