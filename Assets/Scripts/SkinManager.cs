using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;
    [SerializeField] Sprite[] spriteList;
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        SetSkin(Save.current.currentSkin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSkin(int spriteNum){ // 0 = default
        mySpriteRenderer.sprite = spriteList[spriteNum];
    }

}
