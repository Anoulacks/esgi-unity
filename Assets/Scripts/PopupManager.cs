using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupManager : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("LevelMenuScene");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
