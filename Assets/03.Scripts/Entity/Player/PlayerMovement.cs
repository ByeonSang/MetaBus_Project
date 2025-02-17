using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControlls controlls;

    [SerializeField] private float moveSpeed;

    private Vector2 moveInput;
    private Vector2 moveDir;

    private CharacterController characterController;


    private void Awake()
    {
        controlls = new PlayerControlls();

        controlls.Character.Movement.performed += context => moveInput = context.ReadValue<Vector2>();
        controlls.Character.Movement.canceled += context => moveInput = Vector2.zero;
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        moveDir = new Vector2(moveInput.x, moveInput.y);

        if(moveDir.magnitude > 0f)
        {
            characterController.Move(moveDir * moveSpeed * Time.deltaTime);
        }
    }


    // ������Ʈ ���¿� ���� Ȱ��ȭ/��Ȱ��ȭ
    private void OnEnable()
    {
        controlls.Enable();
    }

    private void OnDisable()
    {
        controlls.Disable();
    }
}
