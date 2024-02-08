using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("TrapTag")) {
            Die();
        } else if (collision.gameObject.CompareTag("EnemyTag")) {
            Die();
        }
    }

    private void Die() {
        rigidBody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("deathTrigger");
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
