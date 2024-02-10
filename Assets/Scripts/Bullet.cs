using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletPool pool;
    public BulletPool Pool { get => pool; set => pool = value; }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("EnemyTag")) {
            collider.GetComponent<Enemy>().Die();
        }

        Release();
    }

    public void Release() {
        pool.ReturnToPool(this);
    }
}
