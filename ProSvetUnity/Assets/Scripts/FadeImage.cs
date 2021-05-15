using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeImage : MonoBehaviour, IClickable
{
    public void OnPointerButtonClick()
    {
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<BoxCollider2D>());
    }

    public void OnPointerButtonHold()
    {
        Debug.Log("Pointer button hold Click: " + this.gameObject.name);
    }

    public void OnPointerEnter()
    {
        Debug.Log("Poitner Enter: " + this.gameObject.name);
    }

    public void OnPointerExit()
    {
        Debug.Log("Pointer Exit: " + this.gameObject.name);
    }

}


//public float minimum = 0.0f;
//public float maximum = 1f;
//public float duration = 10.0f;

//bool faded;

//private float startTime;
//public SpriteRenderer rend;

//void Start()
//{
//    startTime = Time.time;
//    faded = true;

//}

//void Update()
//{
//    float t = (Time.time - startTime) / duration;

//    if (faded)
//    {
//        rend.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));
//        if (t > 1f || Input.GetKeyDown(KeyCode.O))
//        {
//            faded = false;
//            startTime = Time.time;
//        }
//    }
//    else
//    {
//        rend.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
//        if (t > 1f || Input.GetKeyDown(KeyCode.O))
//        {
//            faded = true;
//            startTime = Time.time;
//        }
//    }
//}



//public SpriteRenderer rend;
//private bool canFade;
//private float timeFade = 2f;


//void Start()
//{
//    canFade = true;

//    FadeIn();

//    StartCoroutine(FadeControl());
//}

//void FadeIn()
//{
//    image.CrossFadeAlpha(1, timeFade, false);
//}

//void FadeOut()
//{
//    image.CrossFadeAlpha(0, timeFade, false);
//}

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
