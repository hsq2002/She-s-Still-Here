using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// - Add isStabbing animation
// - Add death system (health of 1 for now). It could just be on contact
// with the enemy but maybe if health > 1, player gets knockback and flicker damage effect
// - Add isDying animation
// - Add item pickup system (with inventory of 1 and icon on bottom right 
// indicating what you're holding.
// - Add item reading/interaction system (maybe connected with pickup system? we dont have to tho)

public class PlayerMovement : MonoBehaviour
{
    // private int health = 1;
    [SerializeField] private float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isGamePaused)
        {
            if (rb.velocity != Vector2.zero)
            {
                rb.velocity = Vector2.zero; // stop movement
                StopMovementAnimations();
            }
            return;
        }
        rb.velocity = moveInput * moveSpeed;
        animator.SetBool("isWalking", rb.velocity.sqrMagnitude > 0);
    }

    // Best for physics but maybe can be ignored
    void FixedUpdate()
    {
        return;
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            StopMovementAnimations();
        }
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }

    void StopMovementAnimations()
    {
        animator.SetBool("isWalking", false);
        animator.SetFloat("LastInputX", moveInput.x);
        animator.SetFloat("LastInputY", moveInput.y);
    }

}
