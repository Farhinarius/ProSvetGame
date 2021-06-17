﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlProgressBar : MonoBehaviour
{
    private Image progressBar;

    private bool _triggered;

    private bool _positiveIncrement;

    public float Value => progressBar.fillAmount;
   
    private void Start()
    {
        progressBar = GetComponentInChildren<Image>();
        SetValue(0);
    }

    public void SetValue(float value) => progressBar.fillAmount = value;

    public IEnumerator DrawValue(float limit)
    {
        while ( !Mathf.Approximately(limit, progressBar.fillAmount) )
        {
            yield return new WaitForFixedUpdate();
            progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, limit, Time.fixedDeltaTime * 2);
        }
    }
}
