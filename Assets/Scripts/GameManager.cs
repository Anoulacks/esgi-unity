using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // La seule instance du GameManager
    public static GameManager gameManager;

    private void Awake() {
        // Permet que le Game Manager persiste entre les scènes
        DontDestroyOnLoad(gameObject);

    }
}
