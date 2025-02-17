using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControlls controlls;

    [SerializeField] private float moveSpeed;

    private Vector2 moveInput;
    public Vector2 moveDir;

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
        if (Mathf.Abs(moveInput.x) > 0)
            moveDir = new Vector2(moveInput.x, 0);
        else if (Mathf.Abs(moveInput.y) > 0)
            moveDir = new Vector2(0, moveInput.y);
        else
            moveDir = Vector2.zero;

        if (moveDir.magnitude > 0f)
        {
            characterController.Move(moveDir * moveSpeed * Time.deltaTime);
        }
    }


    // 오브젝트 상태에 따라서 활성화/비활성화
    private void OnEnable()
    {
        controlls.Enable();
    }

    private void OnDisable()
    {
        controlls.Disable();
    }
}
