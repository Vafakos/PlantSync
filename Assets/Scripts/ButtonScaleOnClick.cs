using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScaleOnClick : MonoBehaviour
{

    private Image imageToScale;

    // Start is called before the first frame update
    void Start()
    {
        imageToScale = GetComponent<Image>();
    }

    public void ScaleImage()
    {
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        imageToScale.transform.localScale *= 1.1f;
        yield return new WaitForSeconds(.15f);
        imageToScale.transform.localScale /= 1.1f;
    }
}
