using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private Vector2 movementInput;

    private PlayerMotor motor;
    private PlayerLook look;
    //private PlayerCrouch crouch;
    //private PlayerSprint sprint;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        //jump = GetComponent<PlayerJump>();
        //crouch = GetComponent<PlayerCrouch>();
        //sprint = GetComponent<PlayerSprint>();


        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Sprint.performed += ctx => motor.Sprint();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());

    }
    
    private void LateUpdate() 
    {
         look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable() 
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}