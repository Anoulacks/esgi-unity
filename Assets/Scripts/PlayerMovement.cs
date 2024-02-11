using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    Animator animator;
    [SerializeField] private float jumpForce = 7;
    [SerializeField] private float speed = 3;
    float movementDirection = 0;

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
    }

    void Update() {

        if ( Input.GetKeyDown("space") && isGrounded) {
            Jump();
        }
    }

    void FixedUpdate() {
        // à decommenter pour le déplacement au clavier
        //movementDirection = Input.GetAxisRaw("Horizontal");
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
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if (movementDirection == -1){
            state = MovementStateEnum.running;
            transform.rotation = Quaternion.Euler(0, 180, 0);
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
