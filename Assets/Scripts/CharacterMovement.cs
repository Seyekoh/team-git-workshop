using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Adapted from https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
/// </summary>
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    public float movementSpeed = 10.0f;

    private float forwardDirection;
    private float strafeDirection;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 adjustedDirection = transform.forward * forwardDirection * movementSpeed * Time.deltaTime;
        adjustedDirection += transform.right * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        controller.Move(adjustedDirection);
    }

    private void OnMove(InputValue value)
    {
        Vector2 controls = value.Get<Vector2>();
        forwardDirection = controls.y;
    }
}

