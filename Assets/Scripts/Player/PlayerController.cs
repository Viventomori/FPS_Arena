using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
   private CharacterController controller;
  
    private float playerSpeed = 2.0f;
  


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
     
        
    }

    void Update()
    {
        Vector2 input = playerInput.actions["Movement"].ReadValue<Vector2>();
        Vector3 move = transform.right * input.x + transform.forward * input.y;
        controller.Move(move * playerSpeed * Time.deltaTime);        
    }
}


