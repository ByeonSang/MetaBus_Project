using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControlls controlls;

    [SerializeField] private float moveSpeed;

    private Vector2 moveInput { get; set; }
    public Vector3 moveDir { get; private set; }

    private void Awake()
    {
        controlls = new PlayerControlls();

        controlls.Character.Movement.performed += context => moveInput = context.ReadValue<Vector2>();
        controlls.Character.Movement.canceled += context => moveInput = Vector3.zero;
    }

    private void Update()
    {
        if (Mathf.Abs(moveInput.x) > 0)
            moveDir = Vector3.right * moveInput.x;
        else if (Mathf.Abs(moveInput.y) > 0)
            moveDir = Vector3.up * moveInput.y;
        else
            moveDir = Vector3.zero;

        Debug.Log(moveDir);

        if (moveDir.magnitude > 0f)
        {
            Move(moveDir * moveSpeed * Time.deltaTime);
        }
    }

    public void Move(Vector3 position)
    {
        transform.position += position;
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
