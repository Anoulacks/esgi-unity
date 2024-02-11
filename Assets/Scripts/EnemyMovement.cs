using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject[] points;
    [SerializeField] private bool isRunning = false;
    private int index = 0;
    private float movementDirection = 0;
    Animator animator;

    enum MovementStateEnum { idle, running }

    void Start() {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isRunning) {
            if (Vector2.Distance(points[index].transform.position, transform.position) < .1f) {
                index++;
                if (index >= points.Length) {
                    index = 0;
                }
            }
            movementDirection = (points[index].transform.position - transform.position).normalized.x;
            UpdateAnimation();
            transform.position = Vector2.MoveTowards(transform.position, points[index].transform.position, Time.deltaTime * speed);
        }
    }

    void UpdateAnimation() {

        MovementStateEnum state;

        if (movementDirection > 0) {
            state = MovementStateEnum.running;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if (movementDirection < 0){
            state = MovementStateEnum.running;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else {
            state = MovementStateEnum.idle;
        }
        animator.SetInteger("state", (int)state);
    }
}
