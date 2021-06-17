using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlProgressBar : MonoBehaviour
{
    private Image progressBar;

    private const float increment = 1 / 3;

    private void Start()
    {
        progressBar = GetComponentInChildren<Image>();
        SetValue(0);
    }

    public void SetValue(float value)
    {
        progressBar.fillAmount = value;
    }

    public float Value => progressBar.fillAmount;

    public void DrawValue(bool aboveZero)
    {
        if (aboveZero)
            StartCoroutine(AddDrawingValue(increment));
        else if (!aboveZero)
            StartCoroutine(RemoveDrawingValue(increment));
    }

    public IEnumerator AddDrawingValue(float valueToChange)
    {
        while (Mathf.Abs(progressBar.fillAmount - valueToChange) > Vector2.kEpsilon)
        {
            yield return new WaitForFixedUpdate();
            progressBar.fillAmount += valueToChange / Time.fixedDeltaTime;
        }
    }

    public IEnumerator RemoveDrawingValue(float valueToChange)
    {
        while (Mathf.Abs(progressBar.fillAmount - valueToChange) > Vector2.kEpsilon)
        {
            yield return new WaitForFixedUpdate();
            progressBar.fillAmount -= valueToChange / Time.fixedDeltaTime;
        }
    }

}
