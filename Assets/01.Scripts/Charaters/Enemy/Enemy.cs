using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float detectionRange = 10f; //감지 범위.

    private Transform player;
    private SoundManager soundManager;
    private bool isPlayerInRange = false;


    [field: Header("References")]
    [field: SerializeField] public EnemySO Data { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }
    public CharacterController Controller { get; private set; }

    private EnemyStateMachine stateMachine;

    [field: SerializeField] public Weapon Weapon { get; private set; }
    public CharacterHealth CharacterHealth { get; private set; }

    void Awake()
    {
        AnimationData.Initialize();
        CharacterHealth = GetComponent<CharacterHealth>();
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<ForceReceiver>();

        stateMachine = new EnemyStateMachine(this);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdlingState);
        CharacterHealth.OnDie += OnDie;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        soundManager = SoundManager.Instance;
    }

    private void Update()
    {
        stateMachine.HandleInput();

        stateMachine.Update();

        // 플레이어와 적의 거리 계산
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        // 플레이어가 일정 범위 내에 있는지 확인
        if (distanceToPlayer <= detectionRange)
        {
            if (!isPlayerInRange)
            {
                isPlayerInRange = true;
                // 적의 범위 내로 플레이어가 들어왔을 때 배경 음악 변경
                soundManager.UpdateBackgroundMusic(player.position, transform.position, detectionRange);
            }
        }
        else
        {
            if (isPlayerInRange)
            {
                isPlayerInRange = false;
                // 적의 범위에서 플레이어가 벗어났을 때 원래의 배경 음악으로 복구
                soundManager.RestoreBackgroundMusic();
            }
        }
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }
    void OnDie()
    {
        Animator.SetTrigger("Die");
        enabled = false;
    }
}