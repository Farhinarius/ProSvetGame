using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyChange : MonoBehaviour
{
    [SerializeField] public Sprite[] skies = new Sprite[4];

    [SerializeField] public int skyNum;

    public void Update()
    {

        gameObject.GetComponent<SpriteRenderer>().sprite = skies[skyNum];

    }

}
