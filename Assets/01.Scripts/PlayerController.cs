using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Animator animator;

    public float baseSpeed = 5f; //기본 속도
    public float currentSpeed; //현재 속도
    [Header("Movement")]
    public float moveSpeed = 5f;
    private Vector2 curMovementInput;
    public float jumpForce;
    public LayerMask groundLayerMask;
    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;
    [HideInInspector]
    public bool canLook = true;
    private Rigidbody _rigidbody;
    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
        _rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentSpeed = baseSpeed; //속도
    }
    public void ApplySpeedPotion(float SpeedUp)   //속도
    {
        currentSpeed += SpeedUp;
    }
    public void ResetSpeed()    //속도
    {
        currentSpeed = baseSpeed;
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }
    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;
        _rigidbody.velocity = dir;


    }
    void Run(float additionalSpeed)
    {
        float speed = currentSpeed + additionalSpeed;

        Vector3 movement = new Vector3(curMovementInput.x, 0f, curMovementInput.y) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }
    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
            animator.SetBool("Walk", true);
            if (Keyboard.current.leftShiftKey.isPressed)
            {
                Run(2f);
            }
            else
            {
                Run(0f);
            }
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            animator.SetBool("Walk", false);
        }
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (IsGrounded())
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }


    private bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (Vector3.up * 0.01f) , Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f)+ (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
        };
        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + (transform.forward * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (-transform.forward * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (transform.right * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (-transform.right * 0.2f), Vector3.down);
    }
    public void ToggleCursor(bool toggle)
    {
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }
}