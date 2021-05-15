using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainScript : MonoBehaviour, IClickable
{
    public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite newSprite;
    private string _name;

    void Start()
    {
        _name = this.gameObject.name;
    }

    public void OnPointerButtonClick()
    {
        ChangeSprite(newSprite);
    }

    public void OnPointerButtonHold()
    {
        Debug.Log("Pointer Button Hold: " + _name);
    }

    public void OnPointerEnter()
    {
        Debug.Log("Poitner Enter: " + _name);
    }

    public void OnPointerExit()
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
