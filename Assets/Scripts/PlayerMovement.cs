using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject player;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public float jumpForce = 7;
    public float speed = 3;
    float movementDirection = 0;

    bool isJumping;
    bool isGrounded;

    enum MovementStateEnum { idle, running, jumping, falling }

    private void OnCollisionEnter2D(Collision2D collision) {
        if ( collision.gameObject.CompareTag("FieldTag") ) {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if ( collision.gameObject.CompareTag("FieldTag") ) {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if ( collision.gameObject.CompareTag("FieldTag") ) {
            isGrounded = false;
        }
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if ( Input.GetKeyDown("space") && isGrounded) {
            isJumping = true;
        }
    }

    void FixedUpdate() {

        UpdateAnimation();

        rb.velocity = new Vector2(movementDirection * speed, rb.velocity.y);
    }

    public void Jump() {
        if (isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x , jumpForce);
        }
    }

    public void LeftMovePlayer() {
        movementDirection = -1;
    }

    public void RightMovePlayer() {
        movementDirection = 1;
    }

    public void StopMovePlayer() {
        movementDirection = 0;
    }

    void UpdateAnimation() {

        MovementStateEnum state;

        if (movementDirection == 1) {
            state = MovementStateEnum.running;
            spriteRenderer.flipX = false;
        } else if (movementDirection == -1){
            state = MovementStateEnum.running;
            spriteRenderer.flipX = true;
        } else {
            state = MovementStateEnum.idle;
        }

        if (rb.velocity.y > .1f) {
            state = MovementStateEnum.jumping;
        } else if (rb.velocity.y < -.1f) {
            state = MovementStateEnum.falling;
        }

        animator.SetInteger("state", (int)state);
    }
}
