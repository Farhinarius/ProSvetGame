using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainScript : Interactable
{
    public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite newSprite;

    public override void OnPointerButtonClick()
    {
        ChangeSprite(newSprite);
    }

    public override void OnPointerButtonHold()
    {
        Debug.Log("Pointer Button Hold: " + _name);
    }

    public override void OnPointerEnter()
    {
        Debug.Log("Poitner Enter: " + _name);
    }

    public override void OnPointerExit()
    {
        Debug.Log("Pointer Exit: " + _name);
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
