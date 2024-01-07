using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemTarget : MonoBehaviour
{
    public GameObject scoreManager;

    void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.CompareTag("CoinTag")) {
            Destroy(collision.gameObject);
            scoreManager.GetComponent<Score>().Increment();
        }
    }
}
