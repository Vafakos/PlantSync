using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text moisture;

    private int currentSceneIndex;


    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        GetName();
    }

    public void SaveData()
    {
        SetName();
    }

    // plant's name save
    private void GetName()
    {
        if (currentSceneIndex == 0)
        {
            inputField.text = PlayerPrefs.GetString("PlantNameOne");
        }
        else if (currentSceneIndex == 1)
        {
            inputField.text = PlayerPrefs.GetString("PlantNameTwo");
        }
        else if (currentSceneIndex == 2)
        {
            inputField.text = PlayerPrefs.GetString("PlantNameThree");
        }
    }

    private void SetName()
    {
        if (currentSceneIndex == 0)
        {
            PlayerPrefs.SetString("PlantNameOne", inputField.text);
        }
        else if (currentSceneIndex == 1)
        {
            PlayerPrefs.SetString("PlantNameTwo", inputField.text);
        }
        else if (currentSceneIndex == 2)
        {
            PlayerPrefs.SetString("PlantNameThree", inputField.text);
        }
    }
}

