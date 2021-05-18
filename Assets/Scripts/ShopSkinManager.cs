using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSkinManager : MonoBehaviour
{
    Image myImage;
    [SerializeField]Sprite[] spriteList;
    SwipeMenu swipeMenu;
    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>();
        SetSkin(Save.current.currentSkin);
        swipeMenu = FindObjectOfType<SwipeMenu>();

    }

    // Update is called once per frame
    void Update()
    {
        SetSkin(swipeMenu.GetCurrIndex());

    }
    public void SetSkin(int spriteNum){ // 0 = default
        myImage.sprite = spriteList[spriteNum];
    }
}
