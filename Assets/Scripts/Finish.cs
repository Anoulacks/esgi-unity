using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject popup;

    public delegate void FinishDelegate();
    public static event FinishDelegate OnFinish;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player") {
            OnFinish?.Invoke();
            CompleteLevel();
        }
    }

    private void CompleteLevel() {
        if (popup != null) {
            popup.SetActive(true);
        }
    }
}
