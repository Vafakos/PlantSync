using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleConfirmation : MonoBehaviour
{
    public void Yes()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void No()
    {
        SceneManager.LoadScene(0);
    }
}
