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
    private Rigidbody _rigidbody;
    private SoundManager soundManager;

    public float baseSpeed = 5f; // 기본 속도
    public float runSpeed = 8f;  // 달리는 속도
    public float currentSpeed;  // 현재 속도
    public CharacterHealth CharacterHealth { get; private set; }



    [Header("Movement")]
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

    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
        _rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        soundManager = SoundManager.Instance;
        CharacterHealth = GetComponent<CharacterHealth>();

    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentSpeed = baseSpeed; // 초기화 시 항상 기본 속도로 설정
        CharacterHealth.PlayerDie += GameOver;

    }

    public void ResetSpeed()  
    {
        currentSpeed = baseSpeed;
    }

    private void Update()
    {
        //Debug.Log("현재 속도: " + currentSpeed);
    }

    private void FixedUpdate()
    {
        Move();
        //HandleRunningSound(); // 달리는 소리 관리 메서드 호출
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
        dir *= currentSpeed;
        dir.y = _rigidbody.velocity.y;
        _rigidbody.velocity = dir;


    }
    void Run(float additionalSpeed)
    {
        currentSpeed += additionalSpeed;
        
        //soundManager.PlaySFX("RunningSound");   // 달리기 소리 재생

        //Vector3 movement = new Vector3(curMovementInput.x, 0f, curMovementInput.y) * speed * Time.deltaTime;
        //transform.Translate(movement);
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
            // 이동 입력이 시작될 때 이전에 재생 중인 걷는 소리 중지. 걷는 소리 중첩되지 않도록. 발소리 겹치지 않게.
            soundManager.StopFootstepSFX();

            curMovementInput = context.ReadValue<Vector2>();
            animator.SetBool("Walk", true);

            soundManager.PlaySFX("FootstepSound"); // 걷는 소리만 재생
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            animator.SetBool("Walk", false);

            soundManager.StopFootstepSFX(); // 이동이 멈추면 걷는 소리 중지
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

    //private void HandleRunningSound()
    //{
    //    if (currentSpeed > baseSpeed)
    //    {
    //        soundManager.PlaySFX("RunningSound"); // 달리는 소리 재생
    //    }
    //    else
    //    {
    //        soundManager.StopRunningSFX(); // 달리는 소리 중지
    //    }
    //}

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

    void GameOver()
    {
        Cursor.lockState= CursorLockMode.None;
        Cursor.visible = true;
        UIManager.Instance.GameOverPopup();
        //gameManager.Instance.goToStartScene = true;
    }

}