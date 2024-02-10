using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDeathDelegate();
    public static event EnemyDeathDelegate OnEnemyDeath;
    public void Die() {
        Destroy(gameObject);
        OnEnemyDeath?.Invoke();
    }
}
