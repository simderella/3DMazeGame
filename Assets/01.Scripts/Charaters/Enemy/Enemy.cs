using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float detectionRange = 10f; //���� ����.

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

        // �÷��̾�� ���� �Ÿ� ���
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        // �÷��̾ ���� ���� ���� �ִ��� Ȯ��
        if (distanceToPlayer <= detectionRange)
        {
            if (!isPlayerInRange)
            {
                isPlayerInRange = true;
                // ���� ���� ���� �÷��̾ ������ �� ��� ���� ����
                soundManager.UpdateBackgroundMusic(player.position, transform.position, detectionRange);
            }
        }
        else
        {
            if (isPlayerInRange)
            {
                isPlayerInRange = false;
                // ���� �������� �÷��̾ ����� �� ������ ��� �������� ����
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