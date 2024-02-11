using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private uint initPoolSize;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float speed;
    [SerializeField] private Bullet bullet;
    [SerializeField] private bool autoShoot = false;
    [SerializeField] private int autoShootInterval = 5;

    // Stack qui gère le pool
    private Stack<Bullet> stack;

    public delegate void BulletShootDelegate();
    public static event BulletShootDelegate OnShoot;


    private void Start() {
        SetupPool();

        if (autoShoot) {
            InvokeRepeating("Shoot", 1, autoShootInterval);
        }
    }

    // Création du pool
    private void SetupPool() {
        if (bullet == null) {
            return;
        }

        stack = new Stack<Bullet>();

        // Instancie les éléments du pool
        Bullet instance = null;

        for (int i = 0; i < initPoolSize; i++) {
            instance = Instantiate(bullet);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            stack.Push(instance);
        }
    }

    // Récupère le prochain élément du Pool
    public Bullet GetBullet() {
        if (bullet == null) {
            return null;
        }

        // Rajoute des élements si le Pool est trop petit
        if (stack.Count == 0) {
            Bullet newInstance = Instantiate(bullet);
            newInstance.Pool = this;
            return newInstance;
        }

        // Récupère le prochain élement du Pool
        Bullet nextInstance = stack.Pop();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }

    public void ReturnToPool(Bullet Bullet) {
        // Rajoute l'élément dans le Pool
        stack.Push(Bullet);
        Bullet.gameObject.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.C) && !autoShoot) {
            Shoot();
        }
    }

    public void Shoot() {
        // Récupère une balle du pool
        Bullet bulletObject = GetBullet();

        // Vérifier si la balle n'est pas null avant de la tirer
        if (bulletObject != null) {
            // Positionne la balle au point de tir
            bulletObject.transform.position = shootingPoint.position;
            bulletObject.transform.rotation = transform.rotation;

            // Appliquer une force à la balle
            bulletObject.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            OnShoot?.Invoke();
        }
    }

    private void OnDestroy() {
        CancelInvoke("Shoot");
    }

}
