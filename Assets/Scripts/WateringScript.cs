using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WateringScript : MonoBehaviour
{
    [SerializeField] TMP_Text moistureText;

    [SerializeField] float waterIncreaseBig = 15f;
    [SerializeField] float waterIncreaseSmall = 5f;

    private bool fadeWarning = true;

    private int currentSceneIndex;

    private float moisture;
    private float minMoist = 0;
    private float maxMoist = 101;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        GetMoisture();
    }

    private void Update()
    {
        moistureText.text = Mathf.FloorToInt(moisture).ToString() + "%";
        moisture -= Time.deltaTime;
        CheckMoistureLimits();
    }

    private void OnDestroy()
    {
        SetMoisture();
    }

    // restrict the moisture value 0 < m < 100
    void CheckMoistureLimits()
    {
        if (moisture <= minMoist)
        {
            if (fadeWarning)
            {
                fadeWarning = false;
                LowMoisture();
            }
            moisture = 0;
        }
        else if (moisture >= maxMoist)
        {
            moisture = 101;
        }
    }

    // different water increase based on the button
    public void WaterPlantBig()
    {
        moisture += waterIncreaseBig;
    }

    public void WaterPlantSmall()
    {
        moisture += waterIncreaseSmall;
    }


    // behavior for when the moisture hits 0 %
    private void LowMoisture()
    {
        StartCoroutine(WarningBlink());

        IEnumerator WarningBlink()
        {
            moistureText.color = new Color(moistureText.color.r, moistureText.color.g, moistureText.color.b, 1);
            while (moistureText.color.a > 0.0f)
            {
                moistureText.color = new Color(moistureText.color.r, moistureText.color.g, moistureText.color.b, moistureText.color.a - (Time.deltaTime / 1));
                yield return null;
            }

            moistureText.color = new Color(moistureText.color.r, moistureText.color.g, moistureText.color.b, 0);
            while (moistureText.color.a < 1.0f)
            {
                moistureText.color = new Color(moistureText.color.r, moistureText.color.g, moistureText.color.b, moistureText.color.a + (Time.deltaTime / 1));
                yield return null;
            }
            fadeWarning = true;
        }
    }


    // moisture level save 
    private void SetMoisture()
    {
        if (currentSceneIndex == 0)
        {
            PlayerPrefs.SetFloat("MoistureOne", moisture);
        }
        else if (currentSceneIndex == 1)
        {
            PlayerPrefs.SetFloat("MoistureTwo", moisture);
        }
        else if (currentSceneIndex == 2)
        {
            PlayerPrefs.SetFloat("MoistureThree", moisture);
        }
    }

    private void GetMoisture()
    {
        if (currentSceneIndex == 0)
        {
            moisture = PlayerPrefs.GetFloat("MoistureOne", 50);
        }
        else if (currentSceneIndex == 1)
        {
            moisture = PlayerPrefs.GetFloat("MoistureTwo", 50);
        }
        else if (currentSceneIndex == 2)
        {
            moisture = PlayerPrefs.GetFloat("MoistureThree", 50);
        }
    }
}
