using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource enemyDeathAudioSource;
    [SerializeField] private AudioSource coinAudioSource;
    [SerializeField] private AudioSource finishAudioSource;
    [SerializeField] private AudioSource shootAudioSource;

    // La seule instance du AudioManager
    public static AudioManager audioManager;

    private void Awake() {
        // Permet que le Audio Manager persiste entre les scènes
        DontDestroyOnLoad(gameObject);

    }
    private void OnEnable()
    {
        // S'abonner à l'événement lors de l'activation du script
        Enemy.OnEnemyDeath += EnemyDeathSound;
        Coin.OnCoinCollected += CollectedSound;
        Finish.OnFinish += FinishSound;
        BulletPool.OnShoot += ShootSound;
    }

    private void OnDisable() {
        // Se désabonner de l'événement lors de la désactivation du script
        Enemy.OnEnemyDeath -= EnemyDeathSound;
        Coin.OnCoinCollected -= CollectedSound;
        Finish.OnFinish -= FinishSound;
    }

    private void EnemyDeathSound() {
        enemyDeathAudioSource.Play();
    }

    private void CollectedSound() {
        coinAudioSource.Play();
    }

    private void FinishSound() {
        finishAudioSource.Play();
    }

    private void ShootSound() {
        shootAudioSource.Play();
    }
}
