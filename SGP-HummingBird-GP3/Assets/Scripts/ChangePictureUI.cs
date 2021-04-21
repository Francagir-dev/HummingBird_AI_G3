using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePictureUI : MonoBehaviour
{
    
    [SerializeField] private Image spriteUI;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite spriteToChange;


    public void ChangeSprite()
    {
        Debug.LogWarning(" AHOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOY "+spriteUI.sprite.name);
        spriteUI.sprite = spriteToChange;
    }



    // Update is called once per frame
    void Update()
    {
    }
}