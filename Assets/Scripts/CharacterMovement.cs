using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float charSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    public AnimatorOverrideController animatorOverrideController;

    const string idle = "Idle";

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

        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
    }

    void Update()
    {
        float horizontal = movement.x = Input.GetAxisRaw("Horizontal");
        float vertical = movement.y = Input.GetAxisRaw("Vertical");
        float speed = movement.sqrMagnitude;


        if (movement.x != 0)
        {
            LastHorizontal = movement.x;
        }
        if (movement.y != 0)
        {
            LastVertical = movement.y;
        }

        if (speed == 0)
        {
            if (LastHorizontal == 1)
            {
                animatorOverrideController["Idle"] = Idle_Right;
            }
            if (LastHorizontal == -1)
            {
                animatorOverrideController["Idle"] = Idle_Left;
            }

            if (LastVertical == 1)
            {
                animatorOverrideController["Idle"] = Idle_Up;
            }
            if (LastVertical == -1)
            {
                animatorOverrideController["Idle"] = Idle_Down;
            }
        }
        // Right horizontal = 1, left = -1
        // up vertical = 1, down = -1

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", speed);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * charSpeed * Time.fixedDeltaTime);
    }

}
