using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantMenu : MonoBehaviour
{
    [SerializeField] GameObject Panel;

    private bool isActive;

    public void OpenPanel()
    {
        if (Panel != null)
        {
            isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }

    public void LoadPlantSceneOne()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadPlantSceneTwo()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadPlantSceneThree()
    {
        SceneManager.LoadScene(2);
    }


    // DELETES ALL SAVE FILE DATA (playerprefs)
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}
