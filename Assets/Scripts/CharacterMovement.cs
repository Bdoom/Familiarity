using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private StatsComponent playerStats;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private AnimatorOverrideController animatorOverrideController;

    public AnimationClip Idle_Up;
    public AnimationClip Idle_Down;
    public AnimationClip Idle_Left;
    public AnimationClip Idle_Right;

    private float LastHorizontal = 0;
    private float LastVertical = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerStats = GetComponent<StatsComponent>();

        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        rb.freezeRotation = true;
    }

    void Update()
    {
        float horizontal = movement.x = Input.GetAxisRaw("Horizontal");
        float vertical = movement.y = Input.GetAxisRaw("Vertical");
        float speed = movement.sqrMagnitude;

        if (movement.x != 0 || movement.y != 0)
        {
            LastHorizontal = movement.x;
            LastVertical = movement.y;
        }

        // Right horizontal = 1, left = -1
        // up vertical = 1, down = -1

        animator.SetFloat("Horizontal", LastHorizontal);
        animator.SetFloat("Vertical", LastVertical);
        animator.SetFloat("Speed", speed);

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerStats.MovementSpeed * Time.fixedDeltaTime);
    }

}
