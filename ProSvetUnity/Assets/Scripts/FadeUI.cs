using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour
{
    public Image image;
    //private bool canFade;
    private float timeFade = 2f;


    void Start()
    {
        //canFade = true;
        image.canvasRenderer.SetAlpha(0.0f);
        FadeIn();

        //dialogueTrigger.TriggerDialogue();
        //Debug.Log("диалог должен запуститься");

        //StartCoroutine(FadeControl());
    }

    void FadeIn()
    {
        image.CrossFadeAlpha(1, timeFade, false);
    }

    void FadeOut()
    {
        image.CrossFadeAlpha(0, timeFade, false);
    }

    //IEnumerator FadeControl()
    //{
    //    var material = GetComponent<Renderer>().material;
    //    var color = material.color;
    //    timeToFade += (0.01f * Time.deltaTime)
    //    material.color = new Color(color.r, color.g, color.b, timeToFade);
    //    yield return null;
    //    yield return null;
    //    canFade = false;

    //}
}
