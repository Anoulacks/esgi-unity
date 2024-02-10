using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject scoreManager;

    public delegate void CoinCollectDelegate();
    public static event CoinCollectDelegate OnCoinCollected;

    void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.CompareTag("CoinTag")) {
            Destroy(collision.gameObject);
            OnCoinCollected?.Invoke();
        }
    }
}
