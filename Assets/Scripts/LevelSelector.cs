using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        // Charge le niveau selon le nom de scene
        SceneManager.LoadScene("Level" + level + "Scene");
    }
}
