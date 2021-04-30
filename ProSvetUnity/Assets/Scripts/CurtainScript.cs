using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainScript : MonoBehaviour, IClickable
{
    public SpriteRenderer spriteRenderer;

    [SerializeField] public Sprite newSprite;


    public void OnPointerClick()
    {
        ChangeSprite(newSprite);
    }

    public void OnPointerEnter()
    {
       
    }

    public void OnPointerExit()
    {
      
    }

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        ChangeSprite(newSprite);
    //    }
    //}

    //void Start()
    //{
    //    spriteRenderer = GetComponent<SpriteRenderer>();
    //}

    private void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

}
