using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButtonGenerator : MonoBehaviour
{
    public GameObject buttonLevel; // Référence au préfabriqué de bouton
    public GameObject buttonsContainer; // Référence au conteneur avec VerticalLayoutGroup
    public int numberOfLevels;      // Nombre total de niveaux

    void Start()
    {
        for (int i = 1; i <= numberOfLevels; i++)
        {
            CreateLevelButton(i);
        }
    }

    void CreateLevelButton(int level)
    {
        // Crée une instance du bouton
        GameObject button = Instantiate(buttonLevel, buttonsContainer.transform);

        // Nomme le bouton
        button.name = "Level " + level;

        // Configure le texte du bouton
        TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
        buttonText.text = "Niveau " + level;

        // Listener pour charger le niveau
        button.GetComponent<Button>().onClick.AddListener(() => LoadLevel(level));
    }

    void LoadLevel(int level)
    {
        // Charge le niveau selon le nom de scene
        SceneManager.LoadScene("Level" + level + "Scene");
    }
}
