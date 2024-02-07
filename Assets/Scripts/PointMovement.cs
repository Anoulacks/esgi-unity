using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointMovement : MonoBehaviour
{   [SerializeField] private GameObject[] points;
    private int index = 0;
    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if(Vector2.Distance(points[index].transform.position, transform.position) < .1f) {
            index++;
            if (index >= points.Length) {
                index = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[index].transform.position, Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.name == "Player") {
            collider.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.name == "Player") {
            collider.gameObject.transform.SetParent(null);
        }
    }
}
